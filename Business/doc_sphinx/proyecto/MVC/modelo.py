from MVC.observador import Sujeto
from MVC.logs import registrar_log

class Modelo(Sujeto):
    """
    Clase para gestionar las operaciones de la base de datos relacionadas con los productos.

    Esta clase utiliza una instancia de `Database` para realizar operaciones de alta, consulta, baja y modificación en la tabla `productos`.

    :param db: Instancia de la clase `Database` que se usa para la conexión y operaciones en la base de datos.
    :type db: Database
    """
    def __init__(self, db):
        """
        Inicializa el modelo con una instancia de la clase `Database`.

        :param db: Instancia de la clase `Database` que se usa para la conexión y operaciones en la base de datos.
        :type db: Database
        """
        self.db = db

    @registrar_log
    def alta(self, nombre, cantidad, fecha_compra, foto, comentarios, precio_compra, precio_venta):
        """
        Inserta un nuevo producto en la base de datos.

        :param nombre: Nombre del producto.
        :type nombre: str
        :param cantidad: Cantidad del producto.
        :type cantidad: int
        :param fecha_compra: Fecha de compra del producto en formato 'yyyy-mm-dd'.
        :type fecha_compra: str
        :param foto: Ruta de la imagen del producto.
        :type foto: str
        :param comentarios: Comentarios adicionales sobre el producto.
        :type comentarios: str
        :param precio_compra: Precio de compra del producto.
        :type precio_compra: float
        :param precio_venta: Precio de venta del producto.
        :type precio_venta: float
        """
        con = self.db.con
        cursor = self.db.con.cursor()
        datos = (nombre, cantidad, fecha_compra, foto, comentarios, precio_compra, precio_venta)
        sql = """
            INSERT INTO productos(nombre, cantidad, fecha_compra, foto, comentarios, precio_compra, precio_venta) 
            VALUES(?, ?, ?, ?, ?, ?, ?)
        """
        cursor.execute(sql, datos)
        con.commit()
        
    def consultar_todos(self):
        """
        Consulta todos los productos en la base de datos.

        :return: Lista de tuplas con los datos de todos los productos.
        :rtype: list of tuple
        """
        con = self.db.con
        cursor = con.cursor()
        sql = "SELECT * FROM productos ORDER BY id ASC"
        cursor.execute(sql)
        productos = cursor.fetchall()
        self.notificar(productos)
        return productos

    @registrar_log
    def baja(self, producto_id):
        """
        Elimina un producto de la base de datos por su ID.

        :param producto_id: Identificador del producto a eliminar.
        :type producto_id: int
        """
        con = self.db.con
        cursor = con.cursor()
        data = (producto_id,)
        sql = "DELETE FROM productos WHERE id = ?"
        cursor.execute(sql, data)
        con.commit()
    
    @registrar_log
    def modifica(self, producto_id, nombre, cantidad, fecha_compra, foto, comentarios, precio_compra, precio_venta):
        """
        Modifica los datos de un producto existente en la base de datos.

        :param producto_id: Identificador del producto a modificar.
        :type producto_id: int
        :param nombre: Nuevo nombre del producto.
        :type nombre: str
        :param cantidad: Nueva cantidad del producto.
        :type cantidad: int
        :param fecha_compra: Nueva fecha de compra del producto en formato 'yyyy-mm-dd'.
        :type fecha_compra: str
        :param foto: Nueva ruta de la imagen del producto.
        :type foto: str
        :param comentarios: Nuevos comentarios sobre el producto.
        :type comentarios: str
        :param precio_compra: Nuevo precio de compra del producto.
        :type precio_compra: float
        :param precio_venta: Nuevo precio de venta del producto.
        :type precio_venta: float
        """
        con = self.db.con
        cursor = con.cursor()
        data = (nombre, cantidad, fecha_compra, foto, comentarios, precio_compra, precio_venta, producto_id)
        sql = """
            UPDATE productos 
            SET nombre=?, cantidad=?, fecha_compra=?, foto=?, comentarios=?, precio_compra=?, precio_venta=? 
            WHERE id = ?
        """
        cursor.execute(sql, data)
        con.commit()