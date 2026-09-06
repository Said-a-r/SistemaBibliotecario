namespace SistemaBibliotecario.Models;

public class Libro
{
    public int Codigo {get;set;}
    public string Titulo {get;set;}
    public string Autor {get;set;}
    public bool Disponible {get;set;}
    public string Categoria {get;set;}

    public Libro(int codigo, string titulo, string autor, string categoria)
    {
        Codigo=codigo;
        Titulo=titulo;
        Autor=autor;
        Disponible=true;
        Categoria=categoria;
    }

}