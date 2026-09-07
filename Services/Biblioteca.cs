using SistemaBibliotecario.Interfaces;
using SistemaBibliotecario.Models;
using SistemaBibliotecario.Repositories;

namespace SistemaBibliotecario.Services;

public class Biblioteca
{

    private IRepositorio<Prestamo> repositorioPrestamos;
    private IRepositorio<Libro> repositorioLibros;
    private IRepositorio<Usuario> repositorioUsuarios;

    public string nombreBiblioteca {get;set;}


    public Biblioteca(string nombre)
    {
        nombreBiblioteca=nombre;
        repositorioPrestamos=new Repositorio<Prestamo>();
        repositorioLibros=new Repositorio<Libro>();
        repositorioUsuarios=new Repositorio<Usuario>();
    }


    public void RegistrarLibro(Libro libro)
    {
        var libroAuxi = repositorioLibros
            .ObtenerTodos()
            .FirstOrDefault(l => l.Titulo == libro.Titulo && l.Autor == libro.Autor );
        

        if (libroAuxi != null)
        {
            repositorioLibros.Agregar(libro);
            
        }
        else
        {
            Console.WriteLine("El libro ya existe");
        }

        
    }



    public Usuario? BuscarUsuario(int id)
    {
        return repositorioUsuarios
            .ObtenerTodos()
            .FirstOrDefault(u => u.Id == id);
    }

    public Libro? BuscarLibro(int codigo)
    {
        return repositorioLibros
            .ObtenerTodos()
            .FirstOrDefault(l => l.Codigo == codigo);
    }
    
    public List<Libro> ListarLibros()
    {
        return repositorioLibros
            .ObtenerTodos()
            .OrderBy(l => l.Titulo)
            .ToList();
    }

    public void EliminarLibro(int codigo)
    {
        var libroAux = BuscarLibro(codigo);

       if (libroAux == null){
            Console.WriteLine("El libro no se encuentra en el sitma");
        }else{
            if(libroAux.Disponible == false){
            Console.WriteLine("El libro no se puede eliminar porque esta prestado");
            }
            else
            {
                repositorioLibros.Eliminar(libroAux);
            }

        }
    }

    public List<Libro> ObtenerLibrosDisponibles()
    {
        return repositorioLibros
            .ObtenerTodos()
            .Where(l => l.Disponible==true)
            .OrderBy(l => l.Titulo)
            .ToList();
    }
    
    public List<Libro> BuscarLibroPorAutor(string autor)
    {
        return repositorioLibros
            .ObtenerTodos()
            .Where(l => l.Autor == autor)
            .OrderBy(l => l.Titulo)
            .ToList();
    }

    public List<Libro> BuscarLibroPorCategoria(string categoria)
    {
        return repositorioLibros
            .ObtenerTodos()
            .Where(l => l.Categoria == categoria)
            .OrderBy(l => l.Titulo)
            .ToList();
    }


    public void RegistrarUsuario(Usuario usuario)
    {
        var usuarioExistente = repositorioUsuarios
            .ObtenerTodos()
            .FirstOrDefault(u => u.Id == usuario.Id);

        if (usuarioExistente != null)
        {
            Console.WriteLine("El usuario ya existe en el sistema.");
        }
        else
        {
             repositorioUsuarios.Agregar(usuario);
        }

       
    }


    public List<Usuario> ListarUsuarios()
    {
        return repositorioUsuarios
            .ObtenerTodos()
            .OrderBy(u => u.Nombre)
            .ToList();
    }


   public void RegistrarPrestamo(int codigoLibro, int idUsuario)
    {
        var libro = BuscarLibro(codigoLibro);

        if (libro == null)
        {
            Console.WriteLine("El libro no esta en el sistema");
        }
        else
        {
            if (!libro.Disponible)
            {
                Console.WriteLine("El libro no está disponible.");
            }
            else
            {
                var usuario = BuscarUsuario(idUsuario);
                if (usuario == null){
                    Console.WriteLine("El usuario no existe");
                }
                else
                {
                    libro.Prestar();
                    var prestamo = new Prestamo(codigoLibro,idUsuario,DateTime.Now, null);
                    repositorioPrestamos.Agregar(prestamo);
                }
            }
        }
    }

    public void DevolverLibro(int codigoLibro)
    {
        var libro = BuscarLibro(codigoLibro);

        if (libro == null)
        {
            throw new Exception("El libro no existe en el sistema");
        }else if (libro.Disponible)
        {
            throw new Exception("El libro ya estaba disponible");
        }
        else
        {
            libro.Devolver();

            var prestamo = repositorioPrestamos
            .ObtenerTodos()
            .FirstOrDefault(
            p => p.CodigoLibro == codigoLibro
            );

            repositorioPrestamos.Eliminar(prestamo);

            var prestamoFinalizado = prestamo with{
                FechaDevolucion = DateTime.Now
                };

            repositorioPrestamos.Agregar(prestamoFinalizado);
        }
    }


    public List<Prestamo> ObtenerPrestamosActivos()
    {
        return repositorioPrestamos
            .ObtenerTodos()
            .Where(p => p.FechaDevolucion == null)
            .ToList();
    }

    public void ObtenerInformacionPrestamosActivos(){
        var prestamosActivos = ObtenerPrestamosActivos();
        if (prestamosActivos.Count == 0){
        Console.WriteLine("No existen prestamos");
        }else{
            foreach (var prestamo in prestamosActivos)
            {
                var libro = BuscarLibro(prestamo.CodigoLibro);
                var usuario = BuscarUsuario(prestamo.IdUsuario);
                if (libro != null && usuario != null){
                    Console.WriteLine($"Libro {libro.Titulo}");
                    Console.WriteLine($"Usuario {usuario.Nombre}");
                    Console.WriteLine($"Fecha de préstamo {prestamo.FechaPrestamo}");
                }
            }
        }
    }
}
