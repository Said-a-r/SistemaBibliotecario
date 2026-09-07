namespace SistemaBibliotecario.Interfaces;

public interface IRepositorio<T>
{
    void Agregar(T elemento);
    void Eliminar(T elemento);
    List<T> ObtenerTodos();
}
