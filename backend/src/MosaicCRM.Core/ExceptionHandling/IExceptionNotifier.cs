namespace MosaicCRM.Core.ExceptionHandling;

public interface IExceptionNotifier
{
    Task NotifyAsync(ExceptionNotificationContext context);
}