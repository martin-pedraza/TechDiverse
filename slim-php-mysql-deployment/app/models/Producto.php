<?php

class Producto{
    public $id;
    public $tipo;
    public $detalle;
    public $precio;

    public function crearProducto(){
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "INSERT INTO producto (tipo, detalle, precio) 
            VALUES (:tipo, :detalle, :precio) "
            );
        $consulta->bindValue(':tipo', $this->tipo, PDO::PARAM_STR);
        $consulta->bindValue(':detalle', $this->detalle, PDO::PARAM_STR);
        $consulta->bindValue(':precio', $this->precio, PDO::PARAM_STR);
        $consulta->execute();

        return $objAccesoDatos->obtenerUltimoId();
    }

    public static function obtenerTodos()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "SELECT id, tipo, detalle, precio 
            FROM producto"
            );
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_CLASS, 'Producto');
    }

    public static function obtenerProducto($id)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "SELECT id, tipo, detalle, precio 
            FROM producto
            WHERE id = :id");
        $consulta->bindValue(':id', $id, PDO::PARAM_INT);
        $consulta->execute();

        return $consulta->fetchObject('Producto');
    }

    public static function borrarProducto($id){
        $objAccesoDato = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDato->prepararConsulta(
            "DELETE FROM producto
            WHERE id = :id");
        $consulta->bindValue(':id', $id, PDO::PARAM_INT);
        $consulta->execute();
    }

    public static function obtenerProductosPorPedido($codigo){
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "SELECT pr.* 
            FROM pedido_producto pp 
            INNER JOIN producto pr 
            ON pp.producto = pr.id
            WHERE pp.pedido = :codigo;");
        $consulta->bindValue(':codigo', $codigo, PDO::PARAM_STR);
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_CLASS, 'Producto');
    }

    public static function obtenerProductosPorSector($sector, $codigo, $idProducto){
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "SELECT DISTINCT pr.* 
            FROM pedido_producto pp
            INNER JOIN producto pr
            ON pp.producto = pr.id
            WHERE pr.tipo = :sector AND pp.pedido = :codigo AND pp.producto = :idProducto;");
        $consulta->bindValue(':sector', $sector, PDO::PARAM_STR);
        $consulta->bindValue(':codigo', $codigo, PDO::PARAM_STR);
        $consulta->bindValue(':idProducto', $idProducto, PDO::PARAM_INT);
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_CLASS, 'Producto');
    }
}