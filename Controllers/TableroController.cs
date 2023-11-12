using Microsoft.AspNetCore.Mvc;
using Entidades.Models;
using Entidades.Repositorios;


namespace Kanban.Controllers;


[ApiController]
[Route("[controller]")]
public class TableroController : ControllerBase
{
    private TableroRepository RepoTablero;
    private readonly ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        RepoTablero = new TableroRepository();
    }

// ● POST /api/tablero: Permite crear un nuevo tablero.
    [HttpPost ("api/tablero", Name = "Addtablero")]
    public void Addtablero(Tablero tablero)
    {
        RepoTablero.Create(tablero);
    }

// ● GET /api/tablero: Permite listar los tableros existentes.
    [HttpGet ("api/tablero", Name="Gettableros")]
    public ActionResult<IEnumerable<Tablero>> Gettablero()
    {
        var tablero=RepoTablero.GetAll();
        return Ok(tablero);
    }

// // ● GET /api/tablero/{Id}: Permite buscar un tableros por id.
//     [HttpGet ("api/tablero/{id}", Name = "GettableroId")]
//     public ActionResult<Tablero>GettableroPorId(int id)
//     {
//         Tablero tablero = RepoTablero.GetById(id);
//         if (tablero!=null)
//         {
//             return Ok(tablero);
//         }
//         else{
//             return NotFound("No existe el tablero buscado");
//         }
//     }

// // ● PUT /api/tarea/{Id}/Nombre : Permite modificar un nombre de un tablero.
//     [HttpPut ("api/tarea/{id}/Nombre")]
//     public ActionResult<Boolean>CambiarCadetePedido(int id)
//     {
//         RepoTablero.Remove(id);
//         return Ok("tablero eliminado con exito");
//     }
}

// Crear un Controlador de Tableros (TableroController) que incluya los endpoints para:
// ● POST /api/Tablero: Permite crear un tableros.
// ● GET /api/tableros: Permite listar los tableros existentes.