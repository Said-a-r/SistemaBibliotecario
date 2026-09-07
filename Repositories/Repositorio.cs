using SistemaBibliotecario.Interfaces;

namespace SistemaBibliotecario.Repositories;


public class Repositorio<T> : IRepositorio<T>
{
    private List<T> elementos;

    public Repositorio()
    {
        elementos = new List<T>();
    }

    public void Agregar(T elemento)
    {
        elementos.Add(elemento);
    }

    public void Eliminar(T elemento)
    {
        elementos.Remove(elemento);
    }


    public List<T> ObtenerTodos()
    {
        return elementos;
    }
}