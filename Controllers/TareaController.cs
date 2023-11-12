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

// ● DELETE /api/Tarea/{id}: Elimina una tarea por su ID.
    [HttpDelete ("api/tarea/{id}")]
    public ActionResult<Boolean>Eliminar(int id)
    {
        RepoTarea.Remove(id);
        return Ok("Tarea eliminada con exito");
    }

// ● GET /api/Tarea/{Estado}: Cantidad de tareas en un estado
    [HttpGet ("api/Tarea/{Estado}", Name = "GetTareasPorEstado")]
    public ActionResult<List<Tarea>>GetTareasPorEsTado(EstadoTarea Estado)
    {
       List<Tarea> tareas = RepoTarea.GetTareasPorEstado(Estado);
        if (tareas!=null)
        {
            return Ok(tareas);
        }
        else{
            return NotFound("No existe tarea alguna con el estado buscado");
        }
    }

// ● GET /api/Tarea/Usuario/{Id}: Listar tareas asignada a un usuario
[HttpGet ("/api/Tarea/Usuario/{Id}", Name = "GetTareasPorIdUsuarioAsignado")]
    public ActionResult<List<Tarea>>GetTareasPorIdUsuAsignado(int Id)
    {
       List<Tarea> tareas = RepoTarea.GetTareasPorUsuarioAsignado(Id);
        if (tareas!=null)
        {
            return Ok(tareas);
        }
        else{
            return NotFound("No existe tarea alguna con el Id de usuario asignado");
        }
    }

// ● GET /api/Tarea/Tablero/{Id}: Listar tareas asignada de un tablero
    [HttpGet ("/api/Tarea/Tablero/{Id}", Name = "GetTareasPorIdTableroAsociado")]
    public ActionResult<List<Tarea>>GetTareasPorIdTableroAsociado(int Id)
    {
       List<Tarea> tareas = RepoTarea.GetTareasPorTablero(Id);
        if (tareas!=null)
        {
            return Ok(tareas);
        }
        else{
            return NotFound("No existe tarea alguna con el Id de usuario asignado");
        }
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