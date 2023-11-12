using Microsoft.AspNetCore.Mvc;
using Entidades.Models;
using Entidades.Repositorios;


namespace Kanban.Controllers;


[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioRepository RepoUsuario;
    private readonly ILogger<UsuarioController> _logger;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        RepoUsuario = new UsuarioRepository();
    }

// ● POST /api/usuario: Permite crear un nuevo usuario.
    [HttpPost ("api/usuario", Name = "AddUsuario")]
    public void AddUsuario(Usuario usuario)
    {
        RepoUsuario.Create(usuario);
    }

// ● GET /api/usuario: Permite listar los usuarios existentes.
    [HttpGet ("api/usuario", Name="GetUsuarios")]
    public ActionResult<IEnumerable<Usuario>> GetUsuario()
    {
        var usuario=RepoUsuario.GetAll();
        return Ok(usuario);
    }

// ● GET /api/usuario/{Id}: Permite buscar un usuarios por id.
    [HttpGet ("api/usuario/{id}", Name = "GetUsuarioId")]
    public ActionResult<Usuario>GetUsuarioPorId(int id)
    {
        Usuario usuario = RepoUsuario.GetById(id);
        if (usuario!=null)
        {
            return Ok(usuario);
        }
        else{
            return NotFound("No existe el usuario buscado");
        }
    }

// ● PUT /api/tarea/{Id}/Nombre : Permite modificar un nombre de un Usuario.
    [HttpPut ("api/tarea/{id}/Nombre")]
    public ActionResult<Boolean>ModUsuario(int id,string nombre)
    {
        RepoUsuario.UpdateUsuarioPorNombre(id,nombre);
        return Ok("Usuario eliminado con exito");
    }

}

// Crear un Controlador de Usuarios (UsuarioController) que incluya los endpoints para:
// ● POST /api/usuario: Permite crear un nuevo usuario.
// ● GET /api/usuario: Permite listar los usuarios existentes.
// ● GET /api/usuario/{Id}: Permite buscar un usuarios por id.
// ● PUT /api/tarea/{Id}/Nombre : Permite modificar un nombre de un Usuario.

// Crear un Controlador de Tableros (TableroController) que incluya los endpoints para:
// ● POST /api/Tablero: Permite crear un tableros.
// ● GET /api/tableros: Permite listar los tableros existentes.

// Crear un Controlador de Tareas (TareasController) que incluya los endpoints para:
// ● POST /api/tarea: Permite crear una Tarea.
// ● PUT /api/Tarea/{id}/Nombre/{Nombre}: Permite modificar una Tarea.
// ● PUT /api/Tarea/{id}/Estado/{estado}: Permite modificar el estado de una Tarea.
// ● DELETE /api/Tarea/{id}: Elimina una tarea por su ID.
// ● GET /api/Tarea/{Estado}: Cantidad de tareas en un estado
// ● GET /api/Tarea/Usuario/{Id}: Listar tareas asignada a un usuario
// ● GET /api/Tarea/Tablero/{Id}: Listar tareas asignada de un tablero
