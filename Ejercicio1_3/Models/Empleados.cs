using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Ejercicio1_3.Models
{
    public class Empleados
    { 
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(100)]
        public string Apellidos { get; set; }
        [MaxLength(100)]
        public int Edad { get; set; }
        [MaxLength(100)]
        public string Correo { get; set; }
        [MaxLength(100)]
        public string Direccion { get; set; }
    }
}
