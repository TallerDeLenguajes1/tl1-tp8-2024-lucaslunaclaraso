using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{
     public class Tareas
    {
        private int id;
        private string descripcion;
        private int duracion;

        public int Duracion { get => duracion; set => duracion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Id { get => id; set => id = value; }

        
    }
}
