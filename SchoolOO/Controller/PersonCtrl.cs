using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolOO.DAO;
using System.Collections;

namespace SchoolOO.Controller
{
    class PersonCtrl
    {
        public IList<Person> Consultar()
        {
            return PersonDAO.Consultar();
        }

        public void Salvar(ArrayList arrPerson, string operacao)
        {
            Person person = new Person();
            if (operacao == "incluir")
            {
                person.FirstName = Convert.ToString(arrPerson[0]);
                person.LastName = Convert.ToString(arrPerson[1]);
                person.HireDate = Convert.ToDateTime(arrPerson[2]);
                person.EnrollmentDate = Convert.ToDateTime(arrPerson[3]);
                PersonDAO.Incluir(person);
            }
            else
            {
                person.PersonID = Convert.ToInt32(arrPerson[0]);
                person.FirstName = Convert.ToString(arrPerson[1]);
                person.LastName = Convert.ToString(arrPerson[2]);
                person.HireDate = Convert.ToDateTime(arrPerson[3]);
                person.EnrollmentDate = Convert.ToDateTime(arrPerson[4]);
                if (operacao == "alterar")
                {
                    PersonDAO.Alterar(person);
                }
                else
                {
                    PersonDAO.Excluir(person);
                }
            }
        }
    }
}
