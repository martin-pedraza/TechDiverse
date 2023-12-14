<?php

class Pedido{
    public $id;
    public $codigo;
    public $cliente;
    public $foto;
    public $fechaCreacion;
    public $fechaTerminado;
    public $estado;
    public $tiempo;
    public $mesa;
    public $productos;

    public function crearPedido(){
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "INSERT INTO pedido (codigo, cliente, foto, fechaCreacion, fechaTerminado, estado, tiempo, mesa) 
            VALUES (:codigo, :cliente, :foto, :fechaCreacion, :fechaTerminado, :estado, :tiempo, :mesa)"
            );
        $consulta->bindValue(':codigo', $this->codigo, PDO::PARAM_STR);
        $consulta->bindValue(':cliente', $this->cliente, PDO::PARAM_STR);
        $consulta->bindValue(':foto', $this->foto, PDO::PARAM_STR);
        $consulta->bindValue(':fechaCreacion', $this->fechaCreacion, PDO::PARAM_STR);
        $consulta->bindValue(':fechaTerminado', $this->fechaTerminado, PDO::PARAM_STR);
        $consulta->bindValue(':estado', $this->estado, PDO::PARAM_STR);
        $consulta->bindValue(':tiempo', $this->tiempo, PDO::PARAM_INT);
        $consulta->bindValue(':mesa', $this->mesa, PDO::PARAM_STR);
        $consulta->execute();

        return $objAccesoDatos->obtenerUltimoId();
    }

    public static function obtenerTodos()
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "SELECT id, codigo, cliente, estado, foto, fechaCreacion, fechaTerminado, estado, tiempo, mesa  
            FROM pedido"
            );
        $consulta->execute();

        return $consulta->fetchAll(PDO::FETCH_CLASS, 'Pedido');
    }

    public static function obtenerPedido($codigo)
    {
        $objAccesoDatos = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDatos->prepararConsulta(
            "SELECT id, codigo, cliente, estado, foto, fechaCreacion, fechaTerminado, estado, tiempo, mesa  
            FROM pedido
            WHERE codigo = :codigo");
        $consulta->bindValue(':codigo', $codigo, PDO::PARAM_STR);
        $consulta->execute();

        return $consulta->fetchObject('Pedido');
    }

    public static function modificarEstadoPedido($codigo){
        $estado = "";
        $productos = Pedido_Producto::obtenerTodosPorPedido($codigo);
        
        $minEstado = 5;
        $maxTiempo = 0;
        foreach ($productos as $value) {
            $valor = 5;
            if ($value->estado == 'nuevo') {
                $valor = 0;
            }
            if ($value->estado == 'pendiente') {
                $valor = 1;
            }
            if ($value->estado == 'en preparacion') {
                $valor = 2;
            }
            if ($value->estado == 'listo para servir') {
                $valor = 3;
            }
            if ($value->estado == 'entregado') {
                $valor = 4;
            }
            
            if($valor < $minEstado){
                $minEstado = $valor;
            }

            if ($minEstado != 0 && $minEstado != 5) {
                if ($value->tiempo > $maxTiempo) {
                    $maxTiempo = $value->tiempo;
                }
            }
        }
        
        switch ($minEstado) {
            case 0:
                $estado = 'nuevo';
                break;
            case 1:
                $estado = 'pendiente';
                break;
            case 2:
                $estado = 'en preparacion';
                break;
            case 3:
                $estado = 'listo para servir';
                break;
            case 4:
                $estado = 'entregado';
                break;
            default:
                $estado = 'cancelado';
                break;
        }

        $fechaTerminado = null;
        if($estado == "entregado" || $estado == "cancelado"){
            $fechaTerminado = date("Y-m-d H:i:s");
        }

            
        

        $objAccesoDato = AccesoDatos::obtenerInstancia();
        $consulta = $objAccesoDato->prepararConsulta(
            "UPDATE pedido
            SET estado = :estado, tiempo = :tiempo, fechaTerminado = :fechaTerminado 
            WHERE codigo = :codigo");
        $consulta->bindValue(':codigo', $codigo, PDO::PARAM_STR);
        $consulta->bindValue(':estado', $estado, PDO::PARAM_STR);
        $consulta->bindValue(':tiempo', $maxTiempo, PDO::PARAM_INT);
        $consulta->bindValue(':fechaTerminado', $fechaTerminado, PDO::PARAM_STR);
        $consulta->execute();
    }

    public static function generarCodigo($longitud) {
        $key = '';
        $pattern = '1234567890abcdefghijklmnopqrstuvwxyz';
        $max = strlen($pattern)-1;
        for($i=0; $i < $longitud; $i++){
          $key .= $pattern[mt_rand(0, $max)];
        } 
        return $key;
    }  
}