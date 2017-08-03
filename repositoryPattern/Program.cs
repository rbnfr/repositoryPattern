using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace repositoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var ticket = new Ticket() { Total = 1000 };
            var repositoryTicket = new RepositoryTicket();
            repositoryTicket.Add(ticket);
        }

        public abstract class EntityBase
        {
            public Guid Id { get; set; }
            protected EntityBase Create()
            {
                return new EntityBase() { Id = new Guid() };
            }
            public static Guid CreateIdentifier()
            {
                return new Guid();
            }
        }
        public class Ticket : EntityBase
        {
            public Decimal Total { get; set; }
        }
        public class Person : EntityBase
        {
            public string Name { get; set; }
        }
        public class RepositoryTicket : RepositoryGeneric<Ticket> // Al poner la herencia de repositorygeneric<Person> ya no es necesario implementar el método Add que hay dentro de la clase (lo que está comentado)
        {
            /*public void Add(Ticket ticket)
            {
                ticket.Id = Ticket.CreateIdentifier();
                //TODO
            }*/
        }
        public class RepositoryPerson : RepositoryGeneric<Person> // Al poner la herencia de repositorygeneric<Person> ya no es necesario implementar el método Add que hay dentro de la clase (lo que está comentado). Aquí se podrían añadir más campos ya concretos de person, Id ya lo tendrían porque viene del genérico.
        {
            /*public void Add(Person person)
            {
                person.Id = Person.CreateIdentifier();
                //TODO
            }*/
        }
        public class RepositoryGeneric<T> where T : EntityBase // El where pone una restricción, sólo objetos "T" que hereden de entitybase
        {
            public virtual void Add(T entity)
            {
                entity.Id = EntityBase.CreateIdentifier(); // Los objetos tendrán Id, se pueden añadir más campos.
            }
        }
    }
}
