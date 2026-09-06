
public class Usuario
{
    public int Id {set;get;}
    public string Nombre {set;get;}
    public string Correo {set;get;}


    public Usuario(int id, string nombre, string correo)
    {
        Id=id;
        Nombre=nombre;
        Correo=correo;
    }
}