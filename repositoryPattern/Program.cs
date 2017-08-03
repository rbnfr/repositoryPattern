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
            var numbers = new List<int>()
            {
                1, 2, 3
            };
            var a = 10;
            var result = a.Between(9,20);           // Between aparece con una flecha abajo por ser una extensión. Where también lo es, implementada por microsoft.
            var result2 = numbers.Where(Predicate); // Se le puede pasar el método predicate ya que where si nos vamos con f12 al origen, es una función genérica que requiere especificar la salida y el parámetro, dado que predicate lo cumple, se puede poner como parámetro para utilizarlo.
                                                    // Este where no se implementa hasta que no se itera por él (al hacer debug sí aparecen los elementos, porque s eitera por ella para poder ver los resultados). Se queda como una intención, pero no se ejecuta. Si se muestra por pantalla, no dará el resultado esperado.
            Console.WriteLine(result2);             // Devuelve --> System.Linq.Enumerable+WhereListIterator`1[System.Int32]
                                                    // De aquí viene --> public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate); Se especifica que Tsource será el parámetro de entrada y el utilizado, de ahí que no se pden usar tipos de datos diferentes en el parámetro y luego en el método.
            numbers.Where(n => n > 1);              // Esto es una lambda expression, que no tienen return. n sería value | => es un método anónimo, el que sea, y le decimos que devolverá si n>1. es una función con una entrada, devuelve un booleano, de forma que coincide con el where y puede usarse. Hasta que no iteras sobre ella no existe el resultado. Si añadiera .ToList() al final, entonces sí que existiría el resultado porque se iteraría sobre ella para generar la lista. Si hay que resolver algo y hacer lógica de negocio, se usa tolist, pero si no, no se hace.
            // Sería equivalente a la función de la linea 42 predicate.    
            foreach (var i in Iterator())
            {
                Console.WriteLine(i);
            }

            var resultado = iterar();
            foreach (var value in resultado) // Al iterar por él, aunque no haya código, ya entra. También serviría con las lambda expressions de la linea 23, ya que al iterar sobre ellas devuelven el resultado.
            {

            }
            Console.ReadLine();
            {

            }

        }
        
        static bool Predicate(int value) // Aunque se vaya a usar como un genérico al que le vale todo, al declarar int en el parámetro, limitamos el tipo de datos que acepta el método.
        {
            Console.WriteLine("he entrado");
            return value > 1;
        }
        static IEnumerable<int> Iterator()
        {
            for (var i = 0; i < 100; i++)
            {
                yield return i; // El  yield llama al método predicate. Al devolver un ienumerate, no se devolvería nada hasta iterar las 100 veces, lo que se llama que es bloqueante, pero al poner un yield, hace que el return devuelva el valor que tenga, ya que devuelve el control al que ha invocado al método.
            }
        }
        static bool iterar()
        {
            foreach (var item in collection)
            {

            }
            ?¿
        }
    }

    public static class ExtensionInt // Vamos a extender el tipo entero. Es imprescindible que sea estática para pdoer extenderla.
    {
        public static bool Between(this int value, int from, int to) // El this hace que tome como primer parámetro el valor de nuestra variable sin que tengamos que ponerlo nosotros. Después de this se pude poner tanto un tipo de datos como person, ticket, etc, para que solo se pueda utilizar en esos casos.
        {
            return value >= from && value <= to;
        }
    }

    public class Configuration
    {
        private static Configuration _instance;
        private Configuration()
        {

        }
        public static Configuration Instance
        {
            get
            {
                if (null == _instance)
                {
                    Instance = new Configuration();
                }
                return _instance;
            }
        }
    }
}
