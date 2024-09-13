class Sujeto:
    """
    Clase que representa un sujeto que mantiene una lista de observadores y les notifica los cambios.

    Atributos:
        observadores (list): Lista de observadores registrados.
    """
    observadores = []

    def agregar(self, obj):
        """
        Agrega un observador a la lista de observadores.

        :param obj: El observador que se va a agregar.
        """
        self.observadores.append(obj)

    def notificar(self, *args):
        """
        Notifica a todos los observadores registrados con los argumentos proporcionados.

        :param args: Los argumentos que se pasarán a los métodos de actualización de los observadores.
        """
        for observador in self.observadores:
            observador.update(args)


class Observador:
    """
    Clase base para los observadores. Los observadores concretos deben implementar el método update.

    Método:
        update: Método que debe ser implementado por los observadores concretos para recibir actualizaciones.
    """
    def update(self):
        """
        Método que debe ser implementado por los observadores concretos para recibir actualizaciones.

        :raises NotImplementedError: Si no es implementado por la clase derivada.
        """
        raise NotImplementedError("Delegación de actualización")


class ConcreteObserverA(Observador):
    """
    Observador concreto que calcula la ganancia basada en los datos proporcionados.

    Atributos:
        observador_a (Sujeto): El sujeto al que este observador está registrado.
    """
    def __init__(self, obj):
        """
        Inicializa un observador concreto y lo registra en el sujeto.

        :param obj: El sujeto al que se va a registrar este observador.
        """
        self.observador_a = obj
        self.observador_a.agregar(self)

    def update(self, *args):
        """
        Actualiza el observador calculando la ganancia basada en los datos proporcionados.

        :param args: Datos recibidos del sujeto.
        """
        ganancia = 0
        items = args[0][0]
        for item in items:
            cantidad, precio_compra, precio_venta = item[-6], item[-2], item[-1]
            ganancia += (precio_venta - precio_compra) * cantidad
        print("Ganancia con futuras ventas: $", ganancia)