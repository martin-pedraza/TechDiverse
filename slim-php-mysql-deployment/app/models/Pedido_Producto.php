<?php

class Pedido_Producto{
    public $id;
    public $pedido;
    public $producto;
    public $tiempo;
    public $estado;
    public $cantidad;
    public $detalles;
    public $productos;

    public function crearPedidoProducto(){
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "INSERT INTO pedido_producto (pedido, producto, tiempo, estado, cantidad, detalles) 
            VALUES (:pedido, :producto, :tiempo, :estado, :cantidad, :detalles) "
            );
        $consulta->bindValue(':pedido', $this->pedido, PDO::PARAM_STR);
        $consulta->bindValue(':producto', $this->producto, PDO::PARAM_STR);
        $consulta->bindValue(':tiempo', $this->tiempo, PDO::PARAM_INT);
        $consulta->bindValue(':estado', $this->estado, PDO::PARAM_STR);
        $consulta->bindValue(':cantidad', $this->cantidad, PDO::PARAM_INT);
        $consulta->bindValue(':detalles', $this->detalles, PDO::PARAM_STR);
        $consulta->execute();

        return $objAccesoDatos->obtenerUltimoId();
    }

    public static function obtenerTodosPorPedido($codigo)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "SELECT id, pedido, producto, tiempo, estado, cantidad, detalles 
            FROM pedido_producto
            WHERE pedido = :pedido");
        $consulta->bindValue(':pedido', $codigo, PDO::PARAM_STR);
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_CLASS, 'Pedido_Producto');
    }

    public static function obtenerPedidoProducto($codigo, $idProducto)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "SELECT id, pedido, producto, tiempo, estado,  cantidad, detalles 
            FROM pedido_producto
            WHERE pedido = :pedido AND producto = :producto" );
        $consulta->bindValue(':pedido', $codigo, PDO::PARAM_STR);
        $consulta->bindValue(':producto', $idProducto, PDO::PARAM_INT);
        $consulta->execute();

        return $consulta->fetchObject('Pedido_Producto');
    }

    public static function modificarEstadoPedidoProducto($codigo, $idProducto, $tiempo){
        $estado = "";
        $pedidoProducto = Pedido_Producto::obtenerPedidoProducto($codigo, $idProducto);
        if ($tiempo == null || $pedidoProducto->estado != "nuevo") {
            $tiempo = $pedidoProducto->tiempo;
        }
        
        switch ($pedidoProducto->estado) {
            case 'nuevo':
                $estado = 'pendiente';
                break;
            case 'pendiente':
                $estado = 'en preparacion';
                break;
            case 'en preparacion':
                $estado = 'listo para servir';
                break;
            case 'listo para servir':
                $estado = 'entregado';
                break;
            default:
                $estado = $pedidoProducto->estado;
                break;
        }

        $objAccesoDato = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDato->prepararConsulta(
            "UPDATE pedido_producto
            SET tiempo = :tiempo, estado = :estado
            WHERE pedido = :pedido AND producto = :producto");
        $consulta->bindValue(':producto', $idProducto, PDO::PARAM_INT);
        $consulta->bindValue(':tiempo', $tiempo, PDO::PARAM_INT);
        $consulta->bindValue(':estado', $estado, PDO::PARAM_STR);
        $consulta->bindValue(':pedido', $codigo, PDO::PARAM_STR);
        $consulta->execute();
    }

    public static function cancelarPedidoProducto($codigo, $idProducto){
        $objAccesoDato = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDato->prepararConsulta(
            "UPDATE pedido_producto
            SET estado = :estado
            WHERE pedido = :pedido AND producto = :producto");
        $consulta->bindValue(':producto', $idProducto, PDO::PARAM_INT);
        $consulta->bindValue(':estado', "cancelado", PDO::PARAM_STR);
        $consulta->bindValue(':pedido', $codigo, PDO::PARAM_STR);
        $consulta->execute();
    }

    public static function obtenerProductosPorSector($sector){
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "SELECT pp.* 
            FROM pedido_producto pp
            INNER JOIN producto pr
            ON pp.producto = pr.id
            WHERE pr.tipo = :sector;");
        $consulta->bindValue(':sector', $sector, PDO::PARAM_STR);
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_CLASS, 'Pedido_Producto');
    }
}