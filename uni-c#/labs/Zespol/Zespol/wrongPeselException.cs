using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsobaZespol
{
    /// <summary>
    /// Wyjątek sygnalizujący niepoprawny format numeru PESEL.
    /// Rzucany, gdy wartość PESEL nie spełnia wymogu długości 11 znaków.
    /// </summary>
    public class wrongPeselException : Exception
    {
        /// <summary>
        /// Tworzy nową instancję wyjątku <see cref="wrongPeselException"/>.
        /// </summary>
        /// <param name="message">Komunikat opisujący błąd (np. informacja o niepoprawnym PESEL).</param>
        public wrongPeselException(string message) : base(message)
        {
            //Console.WriteLine(message);
        }
    }
}
