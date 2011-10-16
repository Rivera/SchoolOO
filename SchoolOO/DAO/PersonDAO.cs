using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolOO.DAO
{
    class PersonDAO
    {
        public static IList<Person> Consultar()
        {
            SchoolEntities schoolContext = new SchoolEntities();
            var personQuery = from prs in schoolContext.People
                              orderby prs.FirstName
                              select prs;
            return personQuery.ToList<Person>();
        }

        public static void Incluir(Person person)
        {
            SchoolEntities schoolContext = new SchoolEntities();
            schoolContext.People.AddObject(person);
            schoolContext.SaveChanges();
        }

        public static void Alterar(Person person)
        {
            SchoolEntities schoolContext = new SchoolEntities();
            var queryPerson = (from prs in schoolContext.People
                               where prs.PersonID == person.PersonID
                               select prs).Single<Person>();
            queryPerson.LastName = person.LastName;
            queryPerson.FirstName = person.FirstName;
            queryPerson.HireDate = person.HireDate;
            queryPerson.EnrollmentDate = person.EnrollmentDate;
            schoolContext.SaveChanges();
        }

        public static void Excluir(Person person)
        {
            SchoolEntities schoolContext = new SchoolEntities();
            var personQuery = from prs in schoolContext.People
                              where prs.PersonID == person.PersonID
                              select prs;
            foreach (Person p in personQuery)
            {
                schoolContext.DeleteObject(p);
            }
            schoolContext.SaveChanges();
        }
    }
}
