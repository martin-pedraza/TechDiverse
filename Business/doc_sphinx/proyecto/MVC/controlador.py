from tkinter import filedialog
import os
import shutil
from MVC.validador import Validador

class Controlador:
    """
    Controlador para la aplicación que gestiona las interacciones entre la vista y el modelo.

    :param vista: Instancia de la vista que se usará para la interfaz de usuario.
    :type vista: Vista
    :param modelo: Instancia del modelo que maneja los datos.
    :type modelo: Modelo
    """
    def __init__(self, vista, modelo):
        """
        Inicializa el controlador, vinculando las acciones de la vista a los métodos del controlador.

        :param vista: Instancia de la vista que se usará para la interfaz de usuario.
        :type vista: Vista
        :param modelo: Instancia del modelo que maneja los datos.
        :type modelo: Modelo
        """
        self.vista = vista
        self.modelo = modelo
        
        self.vista.tree.bind("<<TreeviewSelect>>", self.actualizar_campos_seleccion)
        
        # Sobreescritura de funciones de Vista
        self.vista.presionar_boton_foto = self.seleccionar_imagen
        self.vista.presionar_boton_modifica = self.modifica
        self.vista.presionar_boton_borrar = self.baja
        self.vista.presionar_boton_guardar = self.alta
        self.vista.consultar_todos = self.modelo.consultar_todos
        
    def alta(self):
        """
        Realiza la operación de alta de un nuevo producto en el modelo.

        Valida los datos proporcionados en la vista y los envía al modelo. Notifica el éxito o el error a través de la vista.
        """
        nombre = self.vista.nombre_val.get()
        cantidad = self.vista.cantidad_val.get()
        fecha_compra = self.vista.fecha_compra_val.get()
        foto = self.vista.foto_val.get()
        comentarios = self.vista.comentarios_val.get()
        precio_compra = self.vista.precio_compra_val.get()
        precio_venta = self.vista.precio_venta_val.get()
        
        if not Validador.validar_nombre(nombre):
            return self.vista.notificar_evento("Error en nomenclatura")
        
        if not Validador.validar_fecha(fecha_compra):
            return self.vista.notificar_evento("La fecha debe ser yyyy-mm-dd")
        
        if not Validador.validar_numeros_positivos(cantidad, precio_compra, precio_venta):
            return self.vista.notificar_evento("La cantidad y los precios deben ser mayores que cero")
        
        if not foto:
            return self.vista.notificar_evento("Debes escoger una foto")
            
        self.modelo.alta(nombre, cantidad, fecha_compra, foto, comentarios, precio_compra, precio_venta)
        self.vista.borrar_inputs()
        self.vista.mostrar_treeview()
        return self.vista.notificar_evento("Se realizó un alta")

    def baja(self):
        """
        Realiza la operación de baja de un producto en el modelo.

        Elimina el producto seleccionado en la vista y actualiza la interfaz de usuario en consecuencia.
        """
        tree = self.vista.tree
        valor = tree.selection()
        if valor:
            producto_id = tree.item(valor)['text']
            self.modelo.baja(producto_id)
            self.vista.borrar_inputs()
            self.vista.mostrar_treeview()
            return self.vista.notificar_evento("Se realizó una baja")
            
    def modifica(self):
        """
        Realiza la operación de modificación de un producto en el modelo.

        Valida los datos proporcionados en la vista y los envía al modelo para la actualización del producto seleccionado.
        """
        nombre = self.vista.nombre_val.get()
        cantidad = self.vista.cantidad_val.get()
        fecha_compra = self.vista.fecha_compra_val.get()
        foto = self.vista.foto_val.get()
        comentarios = self.vista.comentarios_val.get()
        precio_compra = self.vista.precio_compra_val.get()
        precio_venta = self.vista.precio_venta_val.get()
        tree = self.vista.tree
        
        valor = tree.selection()
        if not valor:
            return self.vista.notificar_evento("No se seleccionó elemento a modificar")
            
        if not Validador.validar_nombre(nombre):
            return self.vista.notificar_evento("Error en nomenclatura")
        
        if not Validador.validar_fecha(fecha_compra):
            return self.vista.notificar_evento("La fecha debe ser yyyy-mm-dd")
        
        if not Validador.validar_numeros_positivos(cantidad, precio_compra, precio_venta):
            return self.vista.notificar_evento("La cantidad y los precios deben ser mayores que cero")
            
        producto_id = tree.item(valor)['text']
        self.modelo.modifica(producto_id, nombre, cantidad, fecha_compra, foto, comentarios, precio_compra, precio_venta)
        self.vista.borrar_inputs()
        self.vista.mostrar_treeview()
        return self.vista.notificar_evento("Se modificó un elemento")
            
    def actualizar_campos_seleccion(self, event):
        """
        Actualiza los campos de entrada en la vista con los datos del producto seleccionado en el Treeview.

        :param event: Evento de selección en el Treeview.
        :type event: tk.Event
        """
        item_seleccionado = self.vista.tree.focus()
        if item_seleccionado:
            self.vista.mostrar_opciones_seleccion()
            self.vista.mostrar_datos_producto()
            valores = self.vista.tree.item(item_seleccionado)['values']
            self.vista.nombre_val.set(valores[0] if valores else "")
            self.vista.cantidad_val.set(valores[1] if valores else "")
            self.vista.fecha_compra_val.set(valores[2] if valores else "")
            if valores[3]:
                self.vista.mostrar_imagen(valores[3])
            self.vista.comentarios_val.set(valores[4] if valores else "")
            self.vista.precio_compra_val.set(valores[5] if valores else "")
            self.vista.precio_venta_val.set(valores[6] if valores else "")
            
    def seleccionar_imagen(self):
        """
        Abre un cuadro de diálogo para seleccionar una imagen y la guarda en la carpeta `img`.

        Actualiza la vista con la ruta de la imagen seleccionada.
        """
        ruta_imagen = filedialog.askopenfilename(filetypes=[("Image files", "*.png;*.jpg;*.jpeg")])
        if ruta_imagen:
            nombre_archivo = os.path.basename(ruta_imagen)
            ruta_destino = os.path.join("img", nombre_archivo)
            if not os.path.exists("img"):
                os.makedirs("img")
            shutil.copy2(ruta_imagen, ruta_destino)
            self.vista.foto_val.set(ruta_destino)
            self.vista.mostrar_imagen(ruta_destino)