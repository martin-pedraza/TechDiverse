from datetime import datetime

def registrar_log(funcion):
    """
    Decorador que registra la acción de una función en un archivo de log.

    :param funcion: La función que se va a decorar.
    :return: La función envuelta que registra en el log.
    """
    def envoltura(*args, **kwargs):
        resultado = funcion(*args, **kwargs)
        registrar_en_log(funcion.__name__, args[1:])
        return resultado
    return envoltura

def registrar_en_log(nombre_funcion, parametros):
    """
    Registra la acción en un archivo de log con la fecha, hora y parámetros.

    :param nombre_funcion: El nombre de la función que se está registrando.
    :param parametros: Los parámetros pasados a la función.
    """
    timestamp = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
    mensaje_registro = f"[{timestamp}] {nombre_funcion} - Parametros: {parametros}\n"

    with open('logs.txt', 'a') as archivo_log:
        archivo_log.write(mensaje_registro)