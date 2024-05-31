using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_clases
{
    public class Paciente : Persona
    {
        // Properties.
        private int id;
        private int phoneNumber;
        private int edad;
        private string provicion;


        // Constructors.
        public Paciente() : base()
        {
            this.setId = 0;
            this.provicion = Provicion.Ninguna.ToString();
            this.setEdad = 0;
            this.setPhoneNumber =0;
        }

        public Paciente(int id, string rut, string name, string lastname, int edad, string gender, int phoneNumber, string provicion) : base(name,lastname,rut,gender)
        {
            this.setId = id;
            this.setEdad = edad;
            this.setPhoneNumber = phoneNumber;
            this.provicion = provicion;
        }
        public Paciente(string rut, string name, string lastname, int edad, string gender, int phoneNumber, string provicion) : base(name, lastname, rut, gender)
        {
            this.setEdad = edad;
            this.setPhoneNumber = phoneNumber;
            this.provicion = provicion;
        }


        // Getters and Setters.
        #region getter setters
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

        private int setPhoneNumber
        {
            set
            {
                if(value == 0 || value.ToString().Length != 9)
                {
                    throw new ArgumentException(string.Format("El numero de telefono debe contener 9 digitos: (9XXXXXXXX)"));
                }
                else
                {
                    phoneNumber = value;
                }
            }
        }
        public int getPhoneNumber
        {
            get { return phoneNumber; }
        }

        private int setEdad
        {
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException(string.Format("La edad no puede ser menor que 0"));
                }
                else
                {
                    edad = value;
                }
            }
        }
        public int getEdad
        {
            get { return edad; }
        }

        public string getProvicion
        {
            get { return provicion; }
        }
        #endregion

    }
}
