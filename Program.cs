var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var RepositorioEnMemoria = new RepositorioEnMemoria();

app.Services.AddSingleton(RepositorioEnMemoria);

app.MapPost("/api/v1/libros", (LibroDTO libroDto) => CrearLibro(libroDto));
app.MapGet("/api/v1/libros/{id}", (Guid id) => ObtenerLibroPorId(id));
app.MapPut("/api/v1/libros/{id}", (Guid id, LibroDTO libroDto) => ActualizarLibro(id, libroDto));
app.MapDelete("/api/v1/libros/{id}", (Guid id) => EliminarLibro(id));

app.MapPost("/api/v1/autores", (AutorDTO autorDto) => CrearAutor(autorDto));
app.MapGet("/api/v1/autores/{id}", (Guid id) => ObtenerAutorPorId(id));
app.MapPut("/api/v1/autores/{id}", (Guid id, AutorDTO autorDto) => ActualizarAutor(id, autorDto));
app.MapDelete("/api/v1/autores/{id}", (Guid id) => EliminarAutor(id));

app.Run();

static Libro CrearLibro(LibroDTO libroDto)
{
    var nuevoLibro = new Libro
    {
        Id = Guid.NewGuid(),
        Título = libroDto.Título,
        Resumen = libroDto.Resumen,
        AutorId = libroDto.AutorId
    };

    RepositorioEnMemoria.Libros.Add(nuevoLibro);

    return nuevoLibro;
}

static Libro ObtenerLibroPorId(Guid id)
{
    var libroEncontrado = RepositorioEnMemoria.Libros.FirstOrDefault(libro => libro.Id == id);

    return libroEncontrado;
}

static Libro ActualizarLibro(Guid id, LibroDTO libroDto)
{
    var libroExistente = RepositorioEnMemoria.Libros.FirstOrDefault(libro => libro.Id == id);

    if (libroExistente != null)
    {
        libroExistente.Título = libroDto.Título;
        libroExistente.Resumen = libroDto.Resumen;
        libroExistente.AutorId = libroDto.AutorId;

        return libroExistente;
    }

    return null;
}

static void EliminarLibro(Guid id)
{
    var libroExistente = RepositorioEnMemoria.Libros.FirstOrDefault(libro => libro.Id == id);

    if (libroExistente != null)
    {
        RepositorioEnMemoria.Libros.Remove(libroExistente);
    }
}

static Autor CrearAutor(AutorDTO autorDto)
{
    var nuevoAutor = new Autor
    {
        Id = Guid.NewGuid(),
        Nombre = autorDto.Nombre,
        Nacionalidad = autorDto.Nacionalidad
    };

    RepositorioEnMemoria.Autores.Add(nuevoAutor);

    return nuevoAutor;
}

static Autor ObtenerAutorPorId(Guid id)
{
    var autorEncontrado = RepositorioEnMemoria.Autores.FirstOrDefault(autor => autor.Id == id);

    return autorEncontrado;
}

static Autor ActualizarAutor(Guid id, AutorDTO autorDto)
{
    var autorExistente = RepositorioEnMemoria.Autores.FirstOrDefault(autor => autor.Id == id);

    if (autorExistente != null)
    {
        autorExistente.Nombre = autorDto.Nombre;
        autorExistente.Nacionalidad = autorDto.Nacionalidad;

        return autorExistente;
    }

    return null;
}

static void EliminarAutor(Guid id)
{
    var autorExistente = RepositorioEnMemoria.Autores.FirstOrDefault(autor => autor.Id == id);

    if (autorExistente != null)
    {
        RepositorioEnMemoria.Autores.Remove(autorExistente);
    }
}
