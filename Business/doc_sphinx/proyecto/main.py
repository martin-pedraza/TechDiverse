from tkinter import Tk

from MVC.modelo import Modelo
from MVC.vista import Vista
from MVC.controlador import Controlador
from MVC.database import Database
from MVC.observador import ConcreteObserverA

class App():
    """
    Clase principal de la aplicación que coordina la inicialización de los componentes
    del patrón MVC (Modelo-Vista-Controlador) y la interacción con la interfaz gráfica
    Tkinter.
    """

    def iniciar(self):
        """
        Método que inicia la aplicación. Crea la ventana principal, inicializa la base
        de datos, la vista, el modelo y el controlador. También establece el protocolo 
        de cierre de la ventana principal.

        :return: None
        """
        root = Tk()
        db = Database()
        vista = Vista(root)
        modelo = Modelo(db)
        controlador = Controlador(vista, modelo)
        observador = ConcreteObserverA(modelo)
        root.protocol("WM_DELETE_WINDOW", lambda: self.on_closing(db, root))
        root.mainloop()
        
    def on_closing(self, db, root):
        """
        Método que se llama al intentar cerrar la ventana principal. Cierra la conexión 
        a la base de datos y destruye la ventana.

        :param db: Instancia de la base de datos.
        :type db: Database
        :param root: Ventana principal de la aplicación.
        :type root: tkinter.Tk
        :return: None
        """
        db.con.close()
        root.destroy()

if __name__ == "__main__":
    app = App()
    app.iniciar()