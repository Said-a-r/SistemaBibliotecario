namespace SistemaBibliotecario.Models;

public record Prestamo(
    int CodigoLibro,
    int IdUsuario,
    DateTime FechaPrestamo,
    DateTime? FechaDevolucion  
);