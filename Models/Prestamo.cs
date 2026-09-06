namespace SistemaBibliotecario.Models;

public record Prestamo
{
    int CodigoLibro {get;set;}
    int IdUsuario {get;set;}
    DateTime FechaPrestamo {get;set;}
    DateTime FechaDevolucion {get;set;}

}