<?php

use Psr\Http\Message\ServerRequestInterface as Request;
use Psr\Http\Server\RequestHandlerInterface as RequestHandler;
use Slim\Psr7\Response as ResponseMW;

class LoggerMiddleware{
    public function __invoke(Request $request, RequestHandler $handler): ResponseMW
    {
        $parametros = $request->getParsedBody();
        $usuario = FALSE;

        if (!is_null($parametros)) {
          if (isset($parametros['nombre']) && isset($parametros['clave'])) {
            $nombre = $parametros['nombre'];
            $clave = $parametros['clave'];
            $usuario = Usuario::validarUsuario($nombre);
            
            if ($usuario !== FALSE && password_verify($clave, $usuario->clave)) {
              $response = $handler->handle($request);
              
              self::iniciarSession($usuario->nombre, $usuario->perfil, $usuario->sector);
            }
          }
        }
        
        if(is_null($parametros) || $usuario === false)
        {
            $response = new ResponseMW();
            $data = array("mensaje" => "Usuario o clave incorrectas");
            $response = $response->withStatus(403);
            $data = json_encode($data);
            $response->getBody()->write($data);
        }

        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    private function iniciarSession($nombre, $perfil, $sector){
        $datos = array('nombre' => $nombre, 'perfil' => $perfil, 'sector' => $sector);
        $token = AutentificadorJWT::CrearToken($datos);
        session_start();
        $_SESSION["jwt"] = $token;
    }
}