using SistemaBibliotecario.Models;
using SistemaBibliotecario.Repositories;
using SistemaBibliotecario.Services;


Biblioteca biblioteca = new Biblioteca("Olivos");

int op=0;


while (op != 10)
{

    Console.WriteLine("1. Registrar libro");
    Console.WriteLine("2. Registrar usuario");
    Console.WriteLine("3. Listar libros");
    Console.WriteLine("4. Buscar libro");
    Console.WriteLine("5. Eliminar libro");
    Console.WriteLine("6. Ver libros disponibles");
    Console.WriteLine("7. Registrar préstamo");
    Console.WriteLine("8. Devolver libro");
    Console.WriteLine("9. Ver prestamos activos");
    Console.WriteLine("10. Salir");
    

    try
    {
        op = int.Parse(Console.ReadLine());

        switch (op)
        {
            case 1:
                Console.WriteLine("codigo del libro ");
                int codigo = int.Parse(Console.ReadLine());

                Console.WriteLine("Titulo: ");
                string titulo = Console.ReadLine();

                Console.WriteLine("Autor ");
                string autor = Console.ReadLine();

                Console.WriteLine("Categoría ");
                string categoria = Console.ReadLine();

                Libro libro = new Libro(codigo, titulo, autor, categoria);

                biblioteca.RegistrarLibro(libro);

                break;


            case 2:
                Console.WriteLine("ID del usuario ");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Nombre ");
                string nombre = Console.ReadLine();

                Console.WriteLine("Correo ");
                string correo = Console.ReadLine();

                Usuario usuario = new Usuario(id, nombre, correo);

                biblioteca.RegistrarUsuario(usuario);

                break;


            case 3:
            {
                 biblioteca.ListarLibros();
                 List<Libro> libros = biblioteca.ListarLibros();
                 if (libros.Count == 0)
                 {
                    Console.WriteLine("No hay libros registrados.");
                    }else{
                        foreach (Libro l in libros){
                            Console.WriteLine($"Codigo: {l.Codigo}");
                        Console.WriteLine($"Titulo: {l.Titulo}");
                        Console.WriteLine($"Autor: {l.Autor}");
                        Console.WriteLine($"Categoria: {l.Categoria}");
                        Console.WriteLine($"Disponible: {l.Disponible}");
                        
                        }
                    }
                        break;
            }

            case 4:
                Console.WriteLine("1. Buscar por codigo");
                Console.WriteLine("2. Buscar por autor");
                Console.WriteLine("3. Buscar por categoria");
                

                int opcionBusqueda = int.Parse(Console.ReadLine());

                if (opcionBusqueda == 1)
                {
                    Console.WriteLine("Codigo del libro ");
                    int codigoBusqueda = int.Parse(Console.ReadLine());

                    Libro? libroEncontrado = biblioteca.BuscarLibro(codigoBusqueda);

                    if (libroEncontrado == null)
                    {
                        Console.WriteLine("No existe el libro con las especifiaciones que diste");
                    }
                    else
                    {
                        Console.WriteLine($"Titulo {libroEncontrado.Titulo}");
                        Console.WriteLine($"Autor {libroEncontrado.Autor}");
                        Console.WriteLine($"Categoria {libroEncontrado.Categoria}");
                        Console.WriteLine($"Codigo {libroEncontrado.Codigo}");
                        Console.WriteLine($"Disponible {libroEncontrado.Disponible}");
                    }
                }
                else if (opcionBusqueda == 2)
                {
                    Console.WriteLine("Autor ");
                    string autorBusqueda = Console.ReadLine();

                    biblioteca.BuscarLibroPorAutor(autorBusqueda);
                }
                else if (opcionBusqueda == 3)
                {
                    Console.WriteLine("Categoria ");
                    string categoriaBusqueda = Console.ReadLine();

                    biblioteca.BuscarLibroPorCategoria(categoriaBusqueda);
                }
                else
                {
                    Console.WriteLine("Elija una opcion d ela lista");
                }

                break;


            case 5:
                Console.WriteLine("Codigo del libro a eliminar ");
                int codigoEliminar = int.Parse(Console.ReadLine());

                biblioteca.EliminarLibro(codigoEliminar);

                break;


            case 6:
                biblioteca.ObtenerLibrosDisponibles();
                List<Libro> librosDisponibles = biblioteca.ObtenerLibrosDisponibles();

                if (librosDisponibles.Count == 0)
                {
                    Console.WriteLine("NO hay libros disponibles al momento");
                }
                else
                {
                    foreach (Libro l in librosDisponibles)
                    {
                        Console.WriteLine($"Codigo {l.Codigo}");
                        Console.WriteLine($"Titulo {l.Titulo}");
                        Console.WriteLine($"Autor {l.Autor}");
                        Console.WriteLine($"Categoria {l.Categoria}");
        
                    }
                }

                break; 
                


            case 7:
                Console.WriteLine("Codigo del libro: ");
                int codigoLibro = int.Parse(Console.ReadLine());

                Console.WriteLine("ID del usuario: ");
                int idUsuario = int.Parse(Console.ReadLine());

                biblioteca.RegistrarPrestamo(codigoLibro, idUsuario);

                break;


            case 8:
                Console.WriteLine("CCodigo del libro a devolver ");
                int codigoDevolver = int.Parse(Console.ReadLine());

                biblioteca.DevolverLibro(codigoDevolver);

                break;


            case 9:
                biblioteca.ObtenerInformacionPrestamosActivos();
                break;



            
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Porfavor ingresar un numero dentro de la lista");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error {ex.Message}");
    }

    

}


