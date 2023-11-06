namespace Crud.DTOs;

public class RepositorioEnMemoria
{
    public List<Autor> Autores { get; } = new List<Autor>();
    public List<Libro> Libros { get; } = new List<Libro>();
}
