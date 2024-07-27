using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_clases
{
     public class Consulta
    {
        private int Consulta_id;
        private int Id_empleado;
        private DateTime Fecha_consulta;


        public Consulta()
        {
            this.Id_empleado = 0;
            this.Consulta_id = 0;
            this.setDate = DateTime.Now;
        }

        public Consulta(int Consulta_id, int Id_empleado, DateTime Fecha_consulta)
        {
            this.setConsulta_id = Consulta_id;
            this.setId_empleado = Id_empleado;
            this.setDate = Fecha_consulta;
        }


        // Setters and Getters
        #region Setters
        private DateTime setDate
        {
            set
            {
                Fecha_consulta = value;
            }
        }

        private int setId_empleado
        {
            set
            {
                if (value < 0 || value.ToString() == "")
                {
                    throw new ArgumentException(string.Format("Error al obtener la id de empleado"));
                }
                else
                {
                    Id_empleado = value;
                }
            }
        }

        private int setConsulta_id
        {
            set
            {
                if (value < 0 || value.ToString() == "")
                {
                    throw new ArgumentException(string.Format("Error al obtener la id de la consulta"));
                }
                else
                {
                    Consulta_id = value;
                }
            }
        }
        #endregion


        #region Getters
        public string getFecha_consulta
        {
            get { return Fecha_consulta.ToString(); }
        }

        public string getId_empleado
        {
            get { return Id_empleado.ToString(); }
        }

        public string getConsulta_id
        {
            get { return Consulta_id.ToString(); }
        }
        #endregion

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
