using MosaicCRM.Core.Exceptions;

namespace MosaicCRM.Core;

public class MosaicCrmExceptionInitialization : MosaicCrmException
{
    

    public MosaicCrmExceptionInitialization(string message)
        : base(message)
    {

    }

    public MosaicCrmExceptionInitialization(string message, Exception innerException)
        : base(message, innerException)
    {

    }

}