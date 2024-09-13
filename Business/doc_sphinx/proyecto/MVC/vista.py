from tkinter import *
from tkinter.messagebox import *
from tkinter import ttk
from PIL import Image, ImageTk

class Vista:
    """
    Clase que gestiona la interfaz gráfica para el manejo de datos de productos.

    Utiliza Tkinter para crear una ventana con formularios para ingresar datos de productos, así como para mostrar una tabla con los productos existentes.
    """

    def __init__(self, root):
        """
        Inicializa la vista con la ventana raíz y configura la interfaz gráfica.

        :param root: Ventana principal de Tkinter.
        :type root: Tk
        """
        self.root = root
        self.root.title("Stock")
        self.root.resizable(width=False, height=False)
        
        # Configuración de las columnas
        col1 = Frame(self.root, width=180)
        col1.grid(row=0, column=0, sticky="n")
        self.root.columnconfigure(0, weight=1)
        
        col2 = Frame(self.root, width=720)
        col2.grid(row=0, column=1, sticky="n")
        self.root.columnconfigure(1, weight=4)

        footer = Frame(self.root)
        footer.grid(row=1, column=0, columnspan=2, sticky="s")
        self.root.columnconfigure(0, weight=1)
        self.root.columnconfigure(1, weight=1)
        
        # Configuración de los componentes de la interfaz
        self.titulo = Label(col2, text="Datos del producto", bg="DarkOrchid3", fg="thistle1", height=1, width=100)
        
        # Variables de los valores de entrada
        self.nombre_val, self.cantidad_val, self.fecha_compra_val, self.foto_val, self.comentarios_val, self.precio_compra_val, self.precio_venta_val = StringVar(), IntVar(), StringVar(), StringVar(), StringVar(), DoubleVar(), DoubleVar()
        w_ancho = 20
        
        # Etiquetas y campos de entrada
        self.nombre_label = Label(col2, text="Nombre")
        self.cantidad_label = Label(col2, text="Cantidad")
        self.fecha_compra_label = Label(col2, text="Fecha de compra")
        self.foto_label = Label(col2, text="Foto")
        self.label_imagen = Label(col2)
        self.precio_compra_label = Label(col2, text="Precio de compra")
        self.precio_venta_label = Label(col2, text="Precio de venta")
        self.comentarios_label = Label(col2, text="Comentarios (opcional)")
        self.titulo.grid(row=0, column=0, columnspan=4, padx=1, pady=1, sticky="ew")
        self.nombre_label.grid(row=1, column=0, sticky="w")
        self.cantidad_label.grid(row=2, column=0, sticky="w")
        self.fecha_compra_label.grid(row=3, column=0, sticky="w")
        self.foto_label.grid(row=4, column=0, sticky="w")
        self.label_imagen.grid(row=4, column=2, pady=10)
        self.precio_compra_label.grid(row=5, column=0, sticky="w")
        self.precio_venta_label.grid(row=6, column=0, sticky="w")
        self.comentarios_label.grid(row=7, column=0, sticky="w")
        
        # Campos de entrada
        self.nombre_input = Entry(col2, textvariable=self.nombre_val, width=w_ancho) 
        self.cantidad_input = Entry(col2, textvariable=self.cantidad_val, width=w_ancho) 
        self.fecha_compra_input = Entry(col2, textvariable=self.fecha_compra_val, width=w_ancho) 
        self.precio_compra_input = Entry(col2, textvariable=self.precio_compra_val, width=w_ancho) 
        self.precio_venta_input = Entry(col2, textvariable=self.precio_venta_val, width=w_ancho) 
        self.comentarios_input = Entry(col2, textvariable=self.comentarios_val, width=w_ancho) 
        self.boton_foto = Button(col2, text="Escoger foto", command=lambda: self.presionar_boton_foto()) 
        self.nombre_input.grid(row=1, column=1)
        self.cantidad_input.grid(row=2, column=1)
        self.fecha_compra_input.grid(row=3, column=1)
        self.boton_foto.grid(row=4, column=1)
        self.precio_compra_input.grid(row=5, column=1)
        self.precio_venta_input.grid(row=6, column=1)
        self.comentarios_input.grid(row=7, column=1)
        
        # Treeview para mostrar productos
        self.tree = ttk.Treeview(col2)
        self.tree["columns"] = ("col1", "col2", "col3", "col4", "col5", "col6", "col7")
        self.tree.column("#0", width=90, minwidth=50, anchor=W)
        self.tree.column("col1", width=100, minwidth=80)
        self.tree.column("col2", width=100, minwidth=80)
        self.tree.column("col3", width=100, minwidth=80)
        self.tree.column("col4", width=100, minwidth=80)
        self.tree.column("col5", width=100, minwidth=80)
        self.tree.column("col6", width=100, minwidth=80)
        self.tree.column("col7", width=100, minwidth=80)
        self.tree.heading("#0", text="ID")
        self.tree.heading("col1", text="Nombre")
        self.tree.heading("col2", text="Cantidad")
        self.tree.heading("col3", text="Fecha de compra")
        self.tree.heading("col4", text="Foto")
        self.tree.heading("col5", text="Comentarios")
        self.tree.heading("col6", text="Precio de compra")
        self.tree.heading("col7", text="Precio de venta")
        
        # Botones
        self.boton_alta = Button(col1, text="Alta", command=lambda:self.mostrar_opciones_alta())
        self.boton_modifica = Button(col1, text="Modifica", command=lambda: self.presionar_boton_modifica())
        self.boton_borrar = Button(col1, text="Baja", command=lambda: self.presionar_boton_borrar())
        self.boton_productos = Button(col1, text="Productos", command=lambda: self.mostrar_treeview())
        self.boton_productos.grid(row=1, column=2)
        self.boton_guardar = Button(col1, text="Guardar", command=lambda: self.presionar_boton_guardar())
        self.boton_guardar.grid(row=5, column=2)
        
        # Eventos
        self.texto_eventos = Text(footer, height=2, state="disabled")
        self.texto_eventos.grid(row=0, column=0, columnspan=2)

    def presionar_boton_foto(self):
        """
        Evento para seleccionar una foto.

        Debe implementar la lógica para permitir al usuario seleccionar una imagen y mostrarla en la interfaz.
        """
        pass

    def presionar_boton_modifica(self):
        """
        Evento para modificar un producto existente.

        Debe implementar la lógica para permitir al usuario modificar los detalles de un producto ya registrado.
        """
        pass

    def presionar_boton_borrar(self):
        """
        Evento para eliminar un producto.

        Debe implementar la lógica para eliminar un producto registrado en la base de datos.
        """
        pass

    def presionar_boton_guardar(self):
        """
        Evento para guardar un nuevo producto.

        Debe implementar la lógica para guardar los detalles de un nuevo producto en la base de datos.
        """
        pass

    def consultar_todos(self):
        """
        Consulta todos los productos registrados.

        :return: Lista de tuplas con los detalles de todos los productos.
        :rtype: list
        """
        pass

    def actualizar_treeview(self):
        """
        Actualiza el Treeview con los datos de todos los productos.

        Llama a `consultar_todos` para obtener los datos y luego actualiza el Treeview con esta información.
        """
        registros = self.consultar_todos()
        self.tree.delete(*self.tree.get_children())
        for fila in registros:
            self.tree.insert("", "end", text=fila[0], values=fila[1:])

    def mostrar_treeview(self):
        """
        Muestra el Treeview y oculta los detalles del producto.

        Actualiza el Treeview con los datos actuales y oculta los formularios de entrada de datos del producto.
        """
        self.mostrar_opciones_tree()
        self.ocultar_datos_producto()
        self.actualizar_treeview()
        self.tree.grid(row=10, column=0, columnspan=4)

    def ocultar_treeview(self):
        """
        Oculta el Treeview.

        Esto puede ser necesario cuando se cambia a una vista diferente en la interfaz.
        """
        self.tree.grid_forget()

    def mostrar_datos_producto(self):
        """
        Muestra los formularios de entrada de datos del producto y oculta el Treeview.

        Configura la interfaz para permitir al usuario ingresar detalles de un nuevo producto.
        """
        self.ocultar_treeview()
        self.ocultar_boton_alta()
        self.titulo.grid(row=0, column=0, columnspan=4, padx=1, pady=1, sticky="ew")
        self.nombre_label.grid(row=1, column=0, sticky="w")
        self.cantidad_label.grid(row=2, column=0, sticky="w")
        self.fecha_compra_label.grid(row=3, column=0, sticky="w")
        self.foto_label.grid(row=4, column=0, sticky="w")
        self.label_imagen.grid(row=4, column=2, pady=10)
        self.precio_compra_label.grid(row=5, column=0, sticky="w")
        self.precio_venta_label.grid(row=6, column=0, sticky="w")
        self.comentarios_label.grid(row=7, column=0, sticky="w")
        self.nombre_input.grid(row=1, column=1)
        self.cantidad_input.grid(row=2, column=1)
        self.fecha_compra_input.grid(row=3, column=1)
        self.boton_foto.grid(row=4, column=1)
        self.precio_compra_input.grid(row=5, column=1)
        self.precio_venta_input.grid(row=6, column=1)
        self.comentarios_input.grid(row=7, column=1)

    def ocultar_datos_producto(self):
        """
        Oculta los formularios de entrada de datos del producto.

        Esto puede ser necesario cuando se cambia a una vista diferente en la interfaz.
        """
        self.titulo.grid_forget()
        self.nombre_label.grid_forget()
        self.cantidad_label.grid_forget()
        self.fecha_compra_label.grid_forget()
        self.foto_label.grid_forget()
        self.label_imagen.grid_forget()
        self.precio_compra_label.grid_forget()
        self.precio_venta_label.grid_forget()
        self.comentarios_label.grid_forget()
        self.nombre_input.grid_forget()
        self.cantidad_input.grid_forget()
        self.fecha_compra_input.grid_forget()
        self.boton_foto.grid_forget()
        self.precio_compra_input.grid_forget()
        self.precio_venta_input.grid_forget()
        self.comentarios_input.grid_forget()

    def borrar_inputs(self):
        """
        Limpia todos los campos de entrada de datos del producto.

        Resetea las variables de entrada y oculta la imagen seleccionada.
        """
        self.nombre_val.set("")
        self.cantidad_val.set("")
        self.fecha_compra_val.set("0")
        self.label_imagen.image = None
        self.label_imagen.configure(image=None)    
        self.comentarios_val.set("")
        self.precio_compra_val.set("0.0")
        self.precio_venta_val.set("0.0")

    def mostrar_imagen(self, ruta_imagen):
        """
        Muestra una imagen en la interfaz gráfica.

        :param ruta_imagen: Ruta del archivo de la imagen.
        :type ruta_imagen: str
        """
        imagen = Image.open(ruta_imagen)
        imagen.thumbnail((100, 100))
        img = ImageTk.PhotoImage(imagen)
        self.label_imagen.configure(image=img)
        self.label_imagen.image = img

    def mostrar_opciones_alta(self):
        """
        Muestra las opciones para agregar un nuevo producto.

        Configura la interfaz para permitir al usuario ingresar los datos de un nuevo producto.
        """
        self.borrar_inputs()
        self.ocultar_boton_alta()
        self.mostrar_boton_guardar()
        self.mostrar_datos_producto()
        self.ocultar_opciones_seleccion()

    def mostrar_opciones_tree(self):
        """
        Muestra las opciones para ver la lista de productos.

        Configura la interfaz para mostrar la tabla de productos y las opciones para modificar o borrar productos.
        """
        self.ocultar_boton_guardar()
        self.mostrar_boton_alta()
        self.ocultar_opciones_seleccion()

    def mostrar_boton_alta(self):
        """
        Muestra el botón para agregar un nuevo producto.

        El botón se muestra en la columna de botones para permitir la adición de un nuevo producto.
        """
        self.boton_alta.grid(row=4, column=2)

    def ocultar_boton_alta(self):
        """
        Oculta el botón para agregar un nuevo producto.

        Esto puede ser necesario cuando se cambia a una vista diferente en la interfaz.
        """
        self.boton_alta.grid_forget()

    def mostrar_boton_guardar(self):
        """
        Muestra el botón para guardar los cambios realizados.

        El botón se muestra en la columna de botones para permitir guardar los datos ingresados.
        """
        self.boton_guardar.grid(row=5, column=2)

    def ocultar_boton_guardar(self):
        """
        Oculta el botón para guardar los cambios realizados.

        Esto puede ser necesario cuando se cambia a una vista diferente en la interfaz.
        """
        self.boton_guardar.grid_forget()

    def mostrar_opciones_seleccion(self):
        """
        Muestra las opciones para modificar o borrar productos.

        Configura la interfaz para permitir al usuario seleccionar un producto para modificar o eliminar.
        """
        self.boton_modifica.grid(row=2, column=2)
        self.boton_borrar.grid(row=3, column=2)

    def ocultar_opciones_seleccion(self):
        """
        Oculta las opciones para modificar o borrar productos.

        Esto puede ser necesario cuando se cambia a una vista diferente en la interfaz.
        """
        self.boton_modifica.grid_forget()
        self.boton_borrar.grid_forget()

    def notificar_evento(self, mensaje):
        """
        Muestra una notificación en el área de texto de eventos.

        :param mensaje: Mensaje a mostrar en la notificación.
        :type mensaje: str
        """
        self.texto_eventos.config(state="normal")
        self.texto_eventos.delete(1.0, END)
        self.texto_eventos.insert(END, mensaje + "\n")
        self.texto_eventos.see(END) 
        self.texto_eventos.config(state="disabled")