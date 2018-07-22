using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistanceCalc.Util
{
    /// <summary>
    /// Custom exception to throw Business Exceptions
    /// </summary>
    public class ECCException : Exception
    {
        public ECCException(string message): base(message)
        {

        }
    }
}
