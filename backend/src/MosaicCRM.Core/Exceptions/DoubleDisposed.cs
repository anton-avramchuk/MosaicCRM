namespace MosaicCRM.Core.Exceptions;

public class DoubleDisposed : MosaicCrmException
{
    public DoubleDisposed() : base("Object disposed more once")
    {
            
    }
}