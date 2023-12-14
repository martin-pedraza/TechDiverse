<?php
require_once "./models/Mesa.php";

class MesaController extends Mesa{
    public function CargarUno($request, $response, $args)
    {
        $parametros = $request->getParsedBody();

        if (!is_null($parametros) && isset($parametros['codigo'])) {
            $codigo = $parametros['codigo'];
            
            $mesa = new Mesa();
            $mesa->codigo = $codigo;
            $mesa->estado = "abierta";
            $mesa->crearMesa();
            
            $payload = json_encode(array("mensaje" => "Mesa creada con exito"));
          }else {
            $payload = json_encode(array("mensaje" => "Falta el campo codigo"));
          }

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerUno($request, $response, $args)
    {
        $codigo = $args['codigo'];
        $mesa = Mesa::obtenerMesa($codigo);
        $payload = json_encode($mesa);

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerTodos($request, $response, $args)
    {
        $lista = Mesa::obtenerTodos();
        $payload = json_encode(array("listaMesa" => $lista));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function CerrarUno($request, $response, $args)
    {
        $codigo = $args['codigo'];
        Mesa::modificarEstadoMesa($codigo, "cerrada");

        $payload = json_encode(array("mensaje" => "Mesa cerrada con exito"));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function AbrirUno($request, $response, $args)
    {
        $codigo = $args['codigo'];
        Mesa::modificarEstadoMesa($codigo, "abierta");

        $payload = json_encode(array("mensaje" => "Mesa reabierta con exito"));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }
}