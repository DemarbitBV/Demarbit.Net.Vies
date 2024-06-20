using System.Diagnostics.CodeAnalysis;

namespace Demarbit.Net.Vies.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ViesModelException(string message) : Exception(message)
    {
    }
}
