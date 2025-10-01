namespace MosaicCRM.Core.ExceptionHandling;

public interface IHasHttpStatusCode
{
    int HttpStatusCode { get; }
}