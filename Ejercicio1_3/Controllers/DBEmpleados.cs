using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Ejercicio1_3.Controllers
{
    public class DBEmpleados
    {

        readonly SQLite.SQLiteAsyncConnection _conexion;


        public DBEmpleados (string dbpath)
        {
             
            _conexion = new SQLiteAsyncConnection(dbpath);

            //Creacion de objeto para la dba 
            _conexion.CreateTableAsync<Models.Empleados>().Wait();
        
        }


        public Task<int> storeEquipo(Models.Empleados personas)
        {
            if (personas.Id == 0)
            {
                return _conexion.InsertAsync(personas);
            }
            else
            {
                return _conexion.UpdateAsync(personas);
            }

        }

        public Task<List<Models.Empleados>> ListaPersonas()
        {
            return _conexion.Table<Models.Empleados>().ToListAsync();
        }

        public Task<Models.Empleados> GetPersonas(int pid)
        {
            return _conexion.Table<Models.Empleados>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        public Task<List<Models.Empleados>> GetItemsByFirstLetterAsync(char letter)
        {
            return _conexion.Table<Models.Empleados>().Where(i => i.Nombre.ToUpper().StartsWith(letter.ToString().ToUpper()))
                             .ToListAsync();
        }





        public Task<int> DeletePersonasItem(Models.Empleados personas)
        {
            return _conexion.DeleteAsync(personas);
        }

    }
}
