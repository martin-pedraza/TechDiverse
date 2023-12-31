<?php
require_once './models/Producto.php';

class ProductoController extends Producto{
    public function CargarUno($request, $response, $args){
        $parametros = $request->getParsedBody();

        if (!is_null($parametros) 
          && isset($parametros['tipo'])
          && isset($parametros['detalle'])
          && isset($parametros['precio'])) {

            $tipo = $parametros['tipo'];
            $detalle = $parametros['detalle'];
            $precio = $parametros['precio'];
            
            $producto = new Producto();
            $producto->tipo = $tipo;
            $producto->detalle = $detalle;
            $producto->precio = $precio;
            $producto->crearProducto();
            
            $payload = json_encode(array("mensaje" => "Producto creado con exito"));
          }else {
            $payload = json_encode(array("mensaje" => "Se debe completar todos los campos(tipo, detalle, precio)"));
          }
            
        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerUno($request, $response, $args)
    {
        $id = $args['id'];
        $producto = Producto::obtenerProducto($id);
        $payload = json_encode($producto);

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function TraerTodos($request, $response, $args)
    {
        $lista = Producto::obtenerTodos();
        $payload = json_encode(array("listaProducto" => $lista));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

    public function BorrarUno($request, $response, $args)
    {
        $id = $args['id'];
        Producto::borrarProducto($id);

        $payload = json_encode(array("mensaje" => "Producto borrado con exito"));

        $response->getBody()->write($payload);
        return $response
          ->withHeader('Content-Type', 'application/json');
    }

}