<?php
require_once './models/Usuario.php';

class UsuarioController extends Usuario
{
    public function CargarUno($request, $response, $args)
    {
        $parametros = $request->getParsedBody();

        if (!is_null($parametros) 
          && isset($parametros['perfil'])
          && isset($parametros['sector'])
          && isset($parametros['nombre'])
          && isset($parametros['clave'])) {

            $perfil = $parametros['perfil'];
            $sector = $parametros['sector'];
            $nombre = $parametros['nombre'];
            $operaciones = 0;
            $fechaRegistro = date("Y-m-d");
            $clave = $parametros['clave'];
            
            $usr = new Usuario();
            $usr->perfil = $perfil;
            $usr->sector = $sector;
            $usr->nombre = $nombre;
            $usr->operaciones = $operaciones;
            $usr->fechaRegistro = $fechaRegistro;
            $usr->clave = $clave;
            $usr->crearUsuario();
            
            $payload = json_encode(array("mensaje" => "Usuario creado con exito"));
          }else {
            $payload = json_encode(array('mensaje' => "Se debe completar todos los campos(perfil, sector, nombre, clave)"));
          }

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerUnoPorNombreClave($request, $response, $args)
    {
        $parametros = $request->getParsedBody();

        if(!is_null($parametros) && isset($parametros['nombre']) && isset($parametros['clave'])){
          $nombre = $parametros['nombre'];
          $clave = $parametros['clave'];
          
          $usuario = Usuario::validarUsuario($nombre);
          if (password_verify($clave, $usuario->clave)) {
            $payload = json_encode($usuario);
          }else{
            $payload = json_encode(array('mensaje' => "Usuario o clave incorrectas"));
          }
        }else{
          $payload = json_encode(array('mensaje' => "Falta parametro nombre y/o clave"));
        }

        $response->getBody()->write($payload);
        
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerUno($request, $response, $args)
    {
        $usr = $args['id'];
        $usuario = Usuario::obtenerUsuario($usr);
        $payload = json_encode($usuario);

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerTodos($request, $response, $args)
    {
        $lista = Usuario::obtenerTodos();
        $payload = json_encode(array("listaUsuario" => $lista));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }
    
    public function ModificarSuspension($request, $response, $args)
    {
        $id = $args['id'];

        Usuario::modificarSuspensionUsuario($id);

        $payload = json_encode(array("mensaje" => "Usuario modificado con exito"));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function BorrarUno($request, $response, $args)
    {
        $id = $args['id'];
        Usuario::borrarUsuario($id);

        $payload = json_encode(array("mensaje" => "Usuario borrado con exito"));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }
}
