<?php
require_once "./models/Pedido.php";
require_once "./models/Pedido_Producto.php";

class PedidoController extends Pedido{
    public function CargarUno($request, $response, $args)
    {
        $parametros = $request->getParsedBody();

        if (!is_null($parametros) 
          && isset($parametros['cliente'])
          && isset($parametros['mesa'])
          && isset($parametros['productos'])) {

              $codigo = Pedido::generarCodigo(5);
              $cliente = $parametros['cliente'];
              $foto = null;
              if (isset($_FILES["foto"])) {
                  $extension = "." . pathinfo($_FILES["foto"]["name"], PATHINFO_EXTENSION);
                  $imagen = $codigo . "_" . date("Y-m-d") . $extension;
                  $destino = "img/" . $imagen;
                  move_uploaded_file($_FILES["foto"]["tmp_name"], $destino);
                  
                  $foto = $imagen;
                }
                $fechaCreacion = date("Y-m-d H:i:s");
                $fechaTerminado = null;
                $estado = "nuevo";
                $tiempo = null;
                $mesa = $parametros['mesa'];
                $productos = json_decode($parametros['productos']);
                
                $pedido = new Pedido();
                $pedido->codigo = $codigo;
                $pedido->cliente = $cliente;
                $pedido->foto = $foto;
                $pedido->fechaCreacion = $fechaCreacion;
                $pedido->fechaTerminado = $fechaTerminado;
                $pedido->estado = $estado;
                $pedido->tiempo = $tiempo;
                $pedido->mesa = $mesa;
                $pedido->productos = null;
                $pedido->crearPedido();
                
                foreach ($productos as $value) {
                    $pedidoProducto = new Pedido_Producto();
                    $pedidoProducto->pedido = $codigo;
                    $pedidoProducto->producto = $value->producto;
                    $pedidoProducto->tiempo = null;
                    $pedidoProducto->estado = "nuevo";
                    $pedidoProducto->cantidad = $value->cantidad;
                    $pedidoProducto->detalles = $value->detalles;
                    $pedidoProducto->crearPedidoProducto();
                }
                
                Mesa::modificarEstadoMesa($mesa, 'con cliente esperando pedido');
                
                $payload = json_encode(array("mensaje" => "Pedido creado con exito"));
            }else {
                $payload = json_encode(array("mensaje" => "Se debe completar todos los campos(cliente, mesa, prodcutos)"));
            }
                
        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerUno($request, $response, $args)
    {
        $codigo = $args['codigo'];
        $pedido = Pedido::obtenerPedido($codigo);
        $pedido->productos = Producto::obtenerProductosPorPedido($codigo);
        $payload = json_encode($pedido);

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerTodos($request, $response, $args)
    {
        $datos = AutentificadorJWT::ObtenerData($_SESSION['jwt']);
        switch ($datos->sector) {
            case 'cocina':
                $sector = 'comida';
                break;
            case 'candybar':
                $sector = 'postre';
                break;
            case 'barra':
                $sector = 'trago';
                break; 
            case 'cerveza':
                $sector = 'cerveza';
                break;   
            default:
                $sector = 'todos';
                break;
        }
        if ($sector == 'todos') {
            $lista = Pedido::obtenerTodos();
            foreach ($lista as $value) {
                $value->productos = Producto::obtenerProductosPorPedido($value->codigo);
            }
        }else{
            $lista = Pedido_Producto::obtenerProductosPorSector($sector);
            foreach ($lista as $value) {
                $value->productos = Producto::obtenerProductosPorSector($sector, $value->pedido, $value->producto);
            }
        }
        $payload = json_encode(array("listaPedido" => $lista));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function ModificarEstado($request, $response, $args)
    {
        $codigo = $args['codigo'];
        $idProducto = $args['producto'];
        $tiempo = null;
        if (isset($request->getQueryParams()['tiempo'])) {
            $tiempo = $request->getQueryParams()['tiempo'];
        }
        
        Pedido_Producto::modificarEstadoPedidoProducto($codigo, $idProducto, $tiempo);
        Pedido::modificarEstadoPedido($codigo);
        $pedido = Pedido::obtenerPedido($codigo);
        if($pedido->estado == "entregado"){
            Mesa::modificarEstadoMesa($pedido->mesa, 'con cliente comiendo');
        }

        $payload = json_encode(array("mensaje" => "Pedido modificado con exito"));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function CancelarUno($request, $response, $args)
    {
        $codigo = $args['codigo'];
        $idProducto = $args['producto'];
        Pedido_Producto::cancelarPedidoProducto($codigo, $idProducto);
        Pedido::modificarEstadoPedido($codigo);

        $pedido = Pedido::obtenerPedido($codigo);
        if($pedido->estado == "cancelado"){
            Mesa::modificarEstadoMesa($pedido->mesa, 'abierta');
        }

        $payload = json_encode(array("mensaje" => "Producto del pedido cancelado con exito"));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function ConsultarUno($request, $response, $args)
    {
        $codigo = $request->getQueryParams()['codigo'];

        $pedido = Pedido::obtenerPedido($codigo);
        $fechaCreacion = new DateTime($pedido->fechaCreacion);
        $intervalo = "PT".$pedido->tiempo."M";
        $nuevaFecha = $fechaCreacion->add(new DateInterval($intervalo));
        $data = array('cliente' => $pedido->cliente, 'mesa' => $pedido->mesa, 'pedido' => $pedido->codigo, 'estado' => $pedido->estado, 'hora estimada de entrega' => $nuevaFecha->format('Y-m-d H:i:s'));
        $payload = json_encode($data);

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }
}