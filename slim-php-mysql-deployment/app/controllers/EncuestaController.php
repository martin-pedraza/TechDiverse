<?php

use Illuminate\Support\Arr;

require_once './models/Encuesta.php';
require_once './models/GestorArchivo.php';

class EncuestaController extends Encuesta{
    public function CargarUno($request, $response, $args){
        $parametros = $request->getParsedBody();

        if (!is_null($parametros) 
          && isset($parametros['mesa'])
          && isset($parametros['detalle'])
          && isset($parametros['puntajeMesa'])
          && isset($parametros['puntajeMozo'])
          && isset($parametros['puntajeCocinero'])
          && isset($parametros['puntajeRestaurante'])) {
            
            
            $encuesta = self::PasarArrayAEncuesta(
              [
                $parametros['mesa'],
                $parametros['detalle'],
                $parametros['puntajeMesa'],
                $parametros['puntajeRestaurante'],
                $parametros['puntajeMozo'],
                $parametros['puntajeCocinero']
              ]
            );
            $encuesta->crearEncuesta();
            
            $payload = json_encode(array("mensaje" => "Encuesta creada con exito"));
          }else {
            $payload = json_encode(array(
              "mensaje" => "Se debe completar todos los campos(mesa, detalle, puntajeMesa, puntajeRestaurante, puntajeMozo, puntajeCocinero)"
            ));
          }
            
        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerUno($request, $response, $args)
    {
        $id = $args['id'];
        $encuesta = Encuesta::obtenerEncuesta($id);
        $payload = json_encode($encuesta);

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerTodos($request, $response, $args)
    {
        $lista = Encuesta::obtenerTodos();
        $payload = json_encode(array("listaEncuesta" => $lista));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function DescargarTodosCSV($request, $response, $args) 
    {
      $lista = Encuesta::obtenerTodos();
      GestorArchivo::Guardar("csv/encuestas.csv", $lista);
      
      $payload = json_encode(array("listaDescargada" => $lista));

      $response->getBody()->write($payload);
      return $response
        ->withHeader('Content-Type', 'application/json');
    }

    public function CargarTodosCSV($request, $response, $args) 
    {
      $listaArray = GestorArchivo::VerificarArchivo("csv/encuestas.csv", array());
      $listaObject = array();

      foreach ($listaArray as $value) {
        $encuesta = self::PasarArrayAEncuesta($value);
        array_push($listaObject, $encuesta);
        $encuesta->crearEncuesta();
      }
      
      $payload = json_encode(array("listaCargada" => $listaObject));

      $response->getBody()->write($payload);
      return $response
        ->withHeader('Content-Type', 'application/json');
    }

    private static function PasarArrayAEncuesta($array) : Encuesta {
      $encuesta = new Encuesta();
      $encuesta->mesa = $array[0];
      $encuesta->detalle = $array[1];
      $encuesta->puntajeMesa = $array[2];
      $encuesta->puntajeRestaurante = $array[3];
      $encuesta->puntajeMozo = $array[4];
      $encuesta->puntajeCocinero = $array[5];
      return $encuesta;
    }
}