<?php
require_once './models/Venta.php';

class VentaController extends Venta{
    public function CargarUno($request, $response, $args){
        $parametros = $request->getParsedBody();
        
        if(!is_null($parametros) && isset($parametros['pedido']) && isset($parametros['mesa'])){
            $pedido = $parametros['pedido'];
            $monto = 0;
            $productos = Producto::obtenerProductosPorPedido($pedido);
            $pedidos = Pedido_Producto::obtenerTodosPorPedido($pedido);
            for ($i=0; $i < count($productos); $i++) { 
                $monto += $productos[$i]->precio * $pedidos[$i]->cantidad;
            }
            $fecha = date("Y-m-d");
            $mesa = $parametros['mesa'];
            
            $venta = new Venta();
            $venta->monto = $monto;
            $venta->fecha = $fecha;
            $venta->pedido = $pedido;
            $venta->mesa = $mesa;
            $venta->crearVenta();
            
            Mesa::modificarEstadoMesa($mesa, 'con cliente pagando');
            
            $payload = json_encode(array("mensaje" => "Venta creada con exito"));
        }else {
            $payload = json_encode(array('mensaje' => "Falta campo pedido y/o mesa"));
        }

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerUno($request, $response, $args)
    {
        $id = $args['id'];
        $venta = Venta::obtenerVenta($id);
        $payload = json_encode($venta);

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerTodos($request, $response, $args)
    {
        $lista = Venta::obtenerTodos();
        $payload = json_encode(array("listaVenta" => $lista));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }
}