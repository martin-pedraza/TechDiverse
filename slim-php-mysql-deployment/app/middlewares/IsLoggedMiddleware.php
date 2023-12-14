<?php

use Psr\Http\Message\ServerRequestInterface as Request;
use Psr\Http\Server\RequestHandlerInterface as RequestHandler;
use Slim\Psr7\Response as ResponseMW;

class IsLoggedMiddleware{
    public function __invoke(Request $request, RequestHandler $handler): ResponseMW
    {
        session_start();
        if (isset($_SESSION["jwt"]) && AutentificadorJWT::VerificarToken($_SESSION["jwt"])) {
            $response = $handler->handle($request);
        }else{
            $response = new ResponseMW();
            $data = array("mensaje" => "Se requiere iniciar sesion");
            $response = $response->withStatus(401);
            $data = json_encode($data);
            $response->getBody()->write($data);
        }

        return $response
          ->withHeader('Content-Type', 'application/json');
    }
}