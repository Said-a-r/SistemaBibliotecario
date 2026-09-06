namespace SistemaBibliotecario.Interfaces;

public interface IRepositorio<T>
{
    void Agregar(T elemento);
    void Eliminar(T elemento);
    T ObtenerPorId(int id);
    List<T> ObtenerTodos();
}
