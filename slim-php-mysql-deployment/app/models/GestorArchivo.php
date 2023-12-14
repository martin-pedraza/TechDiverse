<?php
    class GestorArchivo{
        public static function Guardar($nombreArchivo, $array){
            $archivo = fopen($nombreArchivo, "w");
            
            foreach ($array as $value) {
                fputcsv($archivo, (array)$value);
            }
            
            fclose($archivo);
        }

        public static function VerificarArchivo($nombreArchivo, $array){
            if (file_exists($nombreArchivo) && filesize($nombreArchivo)) {
                $archivo = fopen($nombreArchivo, "r");
                while (!feof($archivo)) {
                    $coleccion = fgetcsv($archivo);
                    if ($coleccion !== false) {
                        array_push($array, $coleccion);
                    }
                }
                fclose($archivo);
            }
            return $array;
        }
    }
?>