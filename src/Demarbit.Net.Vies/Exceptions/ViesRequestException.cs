using System.Diagnostics.CodeAnalysis;

namespace Demarbit.Net.Vies.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ViesRequestException(string message) : Exception(message)
    {
    }
}
