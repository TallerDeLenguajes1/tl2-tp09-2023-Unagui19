namespace EntidadeSpace
{   
    enum EstadoTarea {Ideas, ToDo, Doing, Review, Done};
    class Tareas
    {
        int Id;
        string Nombre;
        string Descripcion;
        string Color;
        EstadoTarea Estado;
        int? IdUsuarioAsignado;
        
    }
}