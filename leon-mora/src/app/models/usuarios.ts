export interface Usuarios {
  id?: string;
  nombre?: string;
  apellido?: string;
  dni?: string;
  cuil?: string;
  foto?: string;
  email?: string;
  clave?: string;
  tipo?: string; // dueño, supervisor, empleado, cliente, cliente-anonimo,
  estado?: string; // Activo, Suspendido, Pendiente-Confirmacion, con mesa
  mesa?: string;
  pedidoActualId?: string;
  pedidoActualEstado?: string;
}
