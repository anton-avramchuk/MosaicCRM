namespace MosaicCRM.Core.ExceptionHandling;

public interface IHasErrorDetails
{
    string? Details { get; }
}