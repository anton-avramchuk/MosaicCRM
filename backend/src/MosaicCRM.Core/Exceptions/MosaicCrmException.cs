namespace MosaicCRM.Core.Exceptions;

public class MosaicCrmException: Exception
{
    public MosaicCrmException()
    {
        
    }
    
    public MosaicCrmException(string message) : base(message) { }

    public MosaicCrmException(string message, Exception innerException) : base(message, innerException) { }
}