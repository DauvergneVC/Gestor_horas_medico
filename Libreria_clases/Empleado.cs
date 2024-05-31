using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_clases
{
    public class Empleado : Persona
    {
        // Properties.
        private int id;
        private string specialty { get; set; }


        // Constructor.
        public Empleado() : base()
        {
            this.setId = 0;
            this.setSpecialty = Specialty.General.ToString();
        }

        public Empleado(int id, string rut, string name, string lastname, string gender, string specialty) : base(name,lastname,rut,gender)
        {
            this.setSpecialty = specialty;
            this.setId = id;
        }


        // Getters and Setters.
        private int setId
        {
            set
            {
                id = value;
            }
        }
        public int getId
        {
            get { return id; }
        }

        private string setSpecialty 
        {
            set { specialty = value; }
        }
        public string getSpecialty
        {
            get { return specialty; }
        }


        // ToString
        public override string ToString()
        {
            return ($"id: {getId} " + base.ToString());
        }
    }
}
