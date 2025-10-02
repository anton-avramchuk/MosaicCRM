namespace MosaicCRM.Core.Exceptions;

public class DoubleDisposed : CrmException
{
    public DoubleDisposed() : base("Object disposed more once")
    {
            
    }
}