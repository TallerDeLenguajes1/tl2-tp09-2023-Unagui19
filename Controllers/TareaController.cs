using Microsoft.AspNetCore.Mvc;
using Entidades.Models;
using Entidades.Repositorios;


namespace Kanban.Controllers;


[ApiController]
[Route("[controller]")]
public class TareaController : ControllerBase
{
    private TareaRepository RepoTarea;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        RepoTarea = new TareaRepository();
    }

// ● POST /api/Tarea: Permite crear un nuevo Tarea.
    [HttpPost ("api/Tarea", Name = "AddTarea")]
    public ActionResult AddTarea(Tarea tarea)
    {
        RepoTarea.Create(tarea);
        return Ok();
    }

// ● GET /api/Tarea: Permite listar los Tareas existentes.
    [HttpGet ("api/Tarea", Name="GetTareas")]
    public ActionResult<IEnumerable<Tarea>> GetTarea()
    {
        var Tarea=RepoTarea.GetAll();
        return Ok(Tarea);
    }

// // ● GET /api/Tarea/{Id}: Permite buscar un Tareas por id.
//     [HttpGet ("api/Tarea/{id}", Name = "GetTareaId")]
//     public ActionResult<Tarea>GetTareaPorId(int id)
//     {
//         Tarea Tarea = RepoTarea.GetById(id);
//         if (Tarea!=null)
//         {
//             return Ok(Tarea);
//         }
//         else{
//             return NotFound("No existe el Tarea buscado");
//         }
//     }

// ● PUT /api/Tarea/{id}/Nombre/{Nombre}: Permite modificar una Tarea.
    [HttpPut ("/api/Tarea/{id}/Nombre/{Nombre}")]
    public ActionResult<bool>ModificarNombreTarea(int id, string Nombre)
    {
          
        RepoTarea.UpdatePorNombre(id,Nombre);
        return Ok("modificacion exitosa");
    }

// ● PUT /api/Tarea/{id}/Estado/{estado}: Permite modificar el estado de una Tarea.
    [HttpPut ("/api/Tarea/{id}/Estado/{estado}")]
    public ActionResult<Boolean>ModificarEstadoTarea(int id, EstadoTarea estado)
    {
        RepoTarea.UpdatePorEstado(id, estado);
        return Ok("Tarea modificada con exito");
    }
}

// Crear un Controlador de Tareas (TareasController) que incluya los endpoints para:
// ● POST /api/tarea: Permite crear una Tarea.
// ● PUT /api/Tarea/{id}/Nombre/{Nombre}: Permite modificar una Tarea.
// ● PUT /api/Tarea/{id}/Estado/{estado}: Permite modificar el estado de una Tarea.
// ● DELETE /api/Tarea/{id}: Elimina una tarea por su ID.
// ● GET /api/Tarea/{Estado}: Cantidad de tareas en un estado
// ● GET /api/Tarea/Usuario/{Id}: Listar tareas asignada a un usuario
// ● GET /api/Tarea/Tablero/{Id}: Listar tareas asignada de un tablero