<?php
// Error Handling
error_reporting(-1);
ini_set('display_errors', 1);

use FastRoute\RouteCollector;
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
use Psr\Http\Server\RequestHandlerInterface  as RequestHandler;
use Slim\Factory\AppFactory;
use Slim\Routing\RouteCollectorProxy;
use Slim\Routing\RouteContext;

require __DIR__ . '/../vendor/autoload.php';

require_once './db/AccesoDatos.php';

require_once './controllers/UsuarioController.php';
require_once './controllers/MesaController.php';
require_once './controllers/PedidoController.php';
require_once './controllers/ProductoController.php';
require_once './controllers/VentaController.php';
require_once './controllers/EncuestaController.php';

require_once './middlewares/AutentificadorJWT.php';
require_once './middlewares/LoggerMiddleware.php';
require_once './middlewares/IsLoggedMiddleware.php';
require_once './middlewares/PerfilMiddleware.php';

// Instantiate App
$app = AppFactory::create();

// Add error middleware
$app->addErrorMiddleware(true, true, true);

// Add parse body
$app->addBodyParsingMiddleware();

// Routes
$app->get('[/]', function (Request $request, Response $response) {    
  $titulo = array(
    'mensaje' => "Bienvenido a la API La Comanda", 
    'desarrollador' => 'Martin Pedraza', 
    'LinkedIn' => 'https://www.linkedin.com/in/pedraza-martindiego/');

  $payload = json_encode($titulo);
  $response->getBody()->write($payload);
  return $response->withHeader('Content-Type', 'application/json');
});

$app->group('/login', function (RouteCollectorProxy $group) {
  $group->post('[/]', \UsuarioController::class . ':TraerUnoPorNombreClave'); 
})->add(new LoggerMiddleware());

$app->group('/logout', function (RouteCollectorProxy $group) {
  $group->get('[/]', function (Request $request, Response $response) {  
    session_start();
    session_unset();
    session_destroy();  
    $payload = json_encode(array('mensaje' => "Sesion cerrada"));
    $response->getBody()->write($payload);
    return $response
      ->withHeader('Content-Type', 'application/json');
  }); 
});

$app->group('/usuarios', function (RouteCollectorProxy $group) {
  $group->post('[/]', \UsuarioController::class . ':CargarUno');
  $group->get('/{id}', \UsuarioController::class . ':TraerUno');
  $group->put('/{id}', \UsuarioController::class . ':ModificarSuspension'); //suspender o reactivar
  $group->delete('/{id}', \UsuarioController::class . ':BorrarUno');
  $group->get('[/]', \UsuarioController::class . ':TraerTodos');
  })->add(new PerfilMiddleware(['socio']))
    ->add(new IsLoggedMiddleware());

$app->group('/mesas', function (RouteCollectorProxy $group) {
  $group->post('[/]', \MesaController::class . ':CargarUno')->add(new PerfilMiddleware(['mozo']));
  $group->put('/{codigo}', \MesaController::class . ':AbrirUno')->add(new PerfilMiddleware(['socio'])); //reabrir
  $group->delete('/{codigo}', \MesaController::class . ':CerrarUno')->add(new PerfilMiddleware(['socio'])); //cerrar
  $group->get('/{codigo}', \MesaController::class . ':TraerUno')->add(new PerfilMiddleware(['mozo']));
  $group->get('[/]', \MesaController::class . ':TraerTodos')->add(new PerfilMiddleware(['mozo']));
  })->add(new IsLoggedMiddleware());

$app->group('/pedidos', function (RouteCollectorProxy $group) {
  $group->post('[/]', \PedidoController::class . ':CargarUno')->add(new PerfilMiddleware(['mozo']));
  $group->get('/{codigo}', \PedidoController::class . ':TraerUno');
  $group->put('/{codigo}/{producto}', \PedidoController::class . ':ModificarEstado'); //pasar siguiente estado al producto
  $group->delete('/{codigo}/{producto}', \PedidoController::class . ':CancelarUno')->add(new PerfilMiddleware(['mozo'])); //cancelar
  $group->get('[/]', \PedidoController::class . ':TraerTodos');
  })->add(new IsLoggedMiddleware());

$app->group('/consulta', function (RouteCollectorProxy $group) {
  $group->get('[/]', \PedidoController::class . ':ConsultarUno');
});

$app->group('/productos', function (RouteCollectorProxy $group) {
  $group->post('[/]', \ProductoController::class . ':CargarUno')->add(new PerfilMiddleware(['cocinero', 'cervecero', 'bartender']));
  $group->get('/{id}', \ProductoController::class . ':TraerUno');
  $group->delete('/{id}', \ProductoController::class . ':BorrarUno')->add(new PerfilMiddleware(['cocinero', 'cervecero', 'bartender']));
  $group->get('[/]', \ProductoController::class . ':TraerTodos');
  })->add(new IsLoggedMiddleware());

$app->group('/ventas', function (RouteCollectorProxy $group) {
  $group->post('[/]', \VentaController::class . ':CargarUno');
  $group->get('/{id}', \VentaController::class . ':TraerUno');
  $group->get('[/]', \VentaController::class . ':TraerTodos');
  })->add(new PerfilMiddleware(['mozo']))
    ->add(new IsLoggedMiddleware());  

$app->group('/encuestas', function (RouteCollectorProxy $group) {
  $group->post('[/]', \EncuestaController::class . ':CargarUno');
  $group->get('/{id}', \EncuestaController::class . ':TraerUno')->add(new PerfilMiddleware(['mozo']))->add(new IsLoggedMiddleware());
  $group->get('[/]', \EncuestaController::class . ':TraerTodos')->add(new PerfilMiddleware(['mozo']))->add(new IsLoggedMiddleware());
  $group->post('/csv/carga', \EncuestaController::class . ':CargarTodosCSV')->add(new PerfilMiddleware(['mozo']))->add(new IsLoggedMiddleware());
  $group->get('/csv/descarga', \EncuestaController::class . ':DescargarTodosCSV')->add(new PerfilMiddleware(['socio']))->add(new IsLoggedMiddleware());
  }); 

$app->run();
