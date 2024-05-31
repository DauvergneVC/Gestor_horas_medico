using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_clases
{
    // this class is a parent for Empleado and Paciente.
    public class Persona
    {
        // Properties.
        private string rut; //In Chile, the Rut can be equals to personal ID.
        private string name;
        private string lastname;
        private string gender;


        // Constructors.
        protected Persona()
        {
            this.setRut = "XXXXXXXX-X";
            this.setName = "default name";
            this.setLastname = "default lastname";
            this.gender = "NoEspecificado";
        }

        protected Persona(string name, string lastname, string rut, string gender)
        {
            this.setName = name;
            this.setLastname = lastname;
            this.setRut = rut;
            this.gender = gender;
        }


        // Getters and Setters.
        #region getters setters
        private string setName
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format("el nombre no puede estar vacio"));
                }
                else
                {
                    name = value;
                }
            }
        }
        public string getName
        {
            get { return name; }
        }

        private string setLastname
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format("el apellido no puede estar vacio"));
                }
                else
                {
                    lastname = value;
                }
            }
        }
        public string getLastname
        {
            get { return lastname; }
        }

        private string setRut
        {
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 10)
                {
                    throw new ArgumentException(string.Format("El rut no debe estar vacio, \ndebe ser correcto y tener formato (XXXXXXXX-X)"));
                }
                else
                {
                    value = value.ToUpper();
                    value = value.Replace(".", "");
                    rut = value;
                }
            }
        }
        public string getRut
        {
            get { return rut; }
        }

        private string setGender
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    gender = Gender.NoEspecificado.ToString();
                }
                else
                {
                    gender = value;
                }
            }
        }
        public string getGender
        {
            get
            {
                return gender;
            }
        }
        #endregion


        // To string
        public override string ToString()
        {
            return ($"rut: {getRut}, name: {getName}, lastname: {getLastname}, gender: {gender}");
        }
    }
}