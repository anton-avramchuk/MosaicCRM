using MosaicCRM.Core.Exceptions;

namespace MosaicCRM.Core;

public class CrmExceptionInitialization : CrmException
{
    

    public CrmExceptionInitialization(string message)
        : base(message)
    {

    }

    public CrmExceptionInitialization(string message, Exception innerException)
        : base(message, innerException)
    {

    }

}