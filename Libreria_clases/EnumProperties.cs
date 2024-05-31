using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria_clases
{
    // Genders for people.
    public enum Gender
    {
        NoEspecificado = 0,
        Masculino = 1,
        Femenino = 2,
        Indefinido = 3
    }

    // specialties for doctors.
    public enum Specialty
    {
        General = 0,
        Psiquiatra = 1,
        Psicologo = 2,
        Gastroenterologo = 3,
        Dentista = 4,
    }

    public enum Provicion
    {
        Ninguna = 0,
        Fonasa = 1,
        Isapre = 2,
    }
}
