using MosaicCRM.Core.Exceptions;

namespace MosaicCRM.Domain.Exceptions;

public class ArgumentMinLengthException : CrmException
{

    public ArgumentMinLengthException(string name, int length) : base($"Invalid Length of {name}. Min is {length}")
    {
    }
}