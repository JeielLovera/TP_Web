using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Implementation;
using Entity;

namespace Business.Implementation
{
    public class Historial_JefeService : IHistorial_JefeService
    {
        private IHistorial_JefeRepository historialRepository = new Historial_JefeRepository();
        private IEmpleadoRepository empleadoRepository = new EmpleadoRepository();
        private IEmpleadoRepository jefeRepository = new EmpleadoRepository();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Historial_Jefe> FindAll()
        {
            return historialRepository.FindAll();
        }

        public Historial_Jefe FindById(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Historial_Jefe t)
        {
            Empleado empleado = empleadoRepository.FindById(t.CEmpleado.CEmpleado);
            Empleado jefe = jefeRepository.FindById(t.CJefe.CEmpleado);
            t.CEmpleado = empleado;
            t.CJefe = jefe;
            return historialRepository.Insert(t);
        }

        public bool Update(Historial_Jefe t)
        {
            Empleado empleado = empleadoRepository.FindById(t.CEmpleado.CEmpleado);
            Empleado jefe = jefeRepository.FindById(t.CJefe.CEmpleado);
            t.CEmpleado = empleado;
            t.CJefe = jefe;
            return historialRepository.Update(t);
        }

        public Historial_Jefe FindById(int? id, int? id2)
        {
            return historialRepository.FindById(id,id2);
        }

        public Historial_Jefe FindById(int? id, int? id2, int? id3)
        {
            throw new NotImplementedException();
        }
    }
}
