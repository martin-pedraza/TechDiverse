import re

class Validador:
    """
    Clase para validar datos de entrada utilizando expresiones regulares y comprobaciones simples.

    Esta clase proporciona métodos estáticos para validar nombres, fechas y números positivos.
    """

    @staticmethod
    def validar_nombre(texto):
        """
        Valida que el texto sea un nombre válido.

        Un nombre válido consiste en letras y espacios, y debe tener al menos un carácter.

        :param texto: Texto a validar.
        :type texto: str
        :return: True si el texto es un nombre válido, False en caso contrario.
        :rtype: bool
        """
        patron = "^[A-Za-z áéíóú]*$"
        return bool(re.match(patron, texto)) and len(texto) > 0

    @staticmethod
    def validar_fecha(fecha):
        """
        Valida que la fecha tenga el formato 'yyyy-mm-dd'.

        :param fecha: Fecha a validar.
        :type fecha: str
        :return: True si la fecha cumple con el formato 'yyyy-mm-dd', False en caso contrario.
        :rtype: bool
        """
        patron = r'^\d{4}-\d{2}-\d{2}$'
        return bool(re.match(patron, fecha))

    @staticmethod
    def validar_numeros_positivos(*numeros):
        """
        Valida que todos los números proporcionados sean mayores que cero.

        :param numeros: Números a validar.
        :type numeros: float
        :return: True si todos los números son positivos, False en caso contrario.
        :rtype: bool
        """
        for numero in numeros:
            if numero <= 0:
                return False
        return True