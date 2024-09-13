import sqlite3

class Database:
    """
    Clase para gestionar la conexión y las operaciones en una base de datos SQLite.

    Esta clase se encarga de conectar con una base de datos SQLite llamada `stock.db` y de crear
    la tabla `productos` si no existe.

    Attributes:
        con (sqlite3.Connection): Conexión a la base de datos SQLite.
    """
    def __init__(self):
        """
        Inicializa la clase, establece la conexión con la base de datos y crea la tabla `productos` si es necesario.
        """
        self.con = self.conectar_base()
        self.crear_tabla()
    
    def conectar_base(self):
        """
        Establece una conexión con la base de datos SQLite.

        :return: Conexión a la base de datos SQLite o None si ocurre un error.
        :rtype: sqlite3.Connection or None
        """
        try:
            con = sqlite3.connect('stock.db')
            return con
        except sqlite3.Error as e:
            print("Error al conectar: ", e)
            return None

    def crear_tabla(self):
        """
        Crea la tabla `productos` en la base de datos si no existe.

        La tabla `productos` tiene las siguientes columnas:
        - id: Identificador único del producto (clave primaria, auto-incremental).
        - nombre: Nombre del producto (cadena de texto, no nula).
        - cantidad: Cantidad del producto (entero, no nulo).
        - fecha_compra: Fecha de compra del producto (fecha, no nula).
        - foto: Ruta de la imagen del producto (cadena de texto, no nula).
        - comentarios: Comentarios adicionales sobre el producto (cadena de texto, puede ser nulo).
        - precio_compra: Precio de compra del producto (real, no nulo).
        - precio_venta: Precio de venta del producto (real, no nulo).

        Si la tabla ya existe, no realiza ninguna acción.
        """
        try:
            cursor = self.con.cursor()
            cursor.execute("SELECT name FROM sqlite_master WHERE type='table' AND name='productos';")
            if cursor.fetchone() is None:
                sql = """
                    CREATE TABLE productos
                    (id integer PRIMARY KEY AUTOINCREMENT, 
                    nombre VARCHAR(50) NOT NULL,
                    cantidad INTEGER NOT NULL,
                    fecha_compra DATE NOT NULL,
                    foto TEXT NOT NULL,
                    comentarios TEXT NULL,
                    precio_compra REAL NOT NULL,
                    precio_venta REAL NOT NULL)
                """
                cursor.execute(sql)
                self.con.commit()
        except sqlite3.Error as e:
            print("Error al crear tabla")