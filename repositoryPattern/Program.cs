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
            var result = a.Between(9,20);// Between aparece con una flecha abajo por ser una extensión. Where también lo es, implementada por microsoft.
            numbers.Where(Predicate); // Se le puede pasar el método predicate ya que where si nos vamos con f12 al origen, es una función genérica que requiere especificar la salida y el parámetro, dado que predicate lo cumple, se puede poner como parámetro para utilizarlo.
            // De aquí viene --> public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate); Se especifica que Tsource será el parámetro de entrada y el utilizado, de ahí que no se pden usar tipos de datos diferentes en el parámetro y luego en el método.
            numbers.Where(n => n > 1); // Esto es una lambda expression, que no tienen return. n sería value | => es un método anónimo, el que sea, y le decimos que devolverá si n>1. es una función con una entrada, devuelve un booleano, de forma que coincide con el where y puede usarse.
            // Sería equivalente a esta función:    
        }
        
        static bool Predicate(int value) // Aunque se vaya a usar como un genérico al que le vale todo, al declarar int en el parámetro, limitamos el tipo de datos que acepta el método.
        {
            return value > 1;
        }
    }

    public static class ExtensionInt // Vamos a extender el tipo entero. Es imprescindible que sea estática para pdoer extenderla.
    {
        public static bool Between(this int value, int from, int to) // El this hace que tome como primer parámetro el valor de nuestra variable sin que tengamos que ponerlo nosotros. Después de this se pude poner tanto un tipo de datos como person, ticket, etc, para que solo se pueda utilizar en esos casos.
        {
            return value >= from && value <= to;
        }
    }
}
