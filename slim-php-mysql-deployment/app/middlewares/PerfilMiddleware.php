<?php

use Psr\Http\Message\ServerRequestInterface as Request;
use Psr\Http\Server\RequestHandlerInterface as RequestHandler;
use Slim\Psr7\Response as ResponseMW;

class PerfilMiddleware{
    private $perfil;

    public function __construct($perfil)
    {
        $this->perfil = $perfil;
    }

    public function __invoke(Request $request, RequestHandler $handler): ResponseMW
    {
        $datos = AutentificadorJWT::ObtenerData($_SESSION['jwt']);
        foreach ($this->perfil as $value) {
            if ($datos->perfil == $value || $datos->perfil == 'socio') {
                $response = $handler->handle($request);
                break;
            }
        }
        
        if (!isset($response)) {
            $response = new ResponseMW();
            $data = array("mensaje" => "Perfil no autorizado");
            $response = $response->withStatus(401);
            $data = json_encode($data);
            $response->getBody()->write($data);
        }

        return $response
          ->withHeader('Content-Type', 'application/json');
    }
}