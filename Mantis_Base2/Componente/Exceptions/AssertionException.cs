using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.Exceptions
{
    class AssertionException : Exception
    {
        public AssertionException(string esperado, string exibido) : base($"Foi esperado o valor '{esperado}' mas foi exibido '{exibido}'") { }
    }
}
