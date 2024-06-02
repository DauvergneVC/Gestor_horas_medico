using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_clases
{
     public class Consulta
    {
        private int id;
        private DateTime date;
        

        public Consulta()
        {
            this.id = 0;
            this.setDate = DateTime.Now;
        }

        public Consulta(DateTime date)
        {
            this.setDate = date;
        }


        // Setters and Getters
        #region Setters
        private DateTime setDate
        {
            set
            {
                if (value < DateTime.Now || value.ToString() == "")
                {
                    throw new ArgumentException(string.Format("debe seleccionar una fecha posterior al dia de hoy"));
                }
                else
                {
                    date = value;
                }
            }

        }
        #endregion

        #region Getters
        public DateTime getDate
        {
            get { return date; }
        }
        #endregion
    }
}
