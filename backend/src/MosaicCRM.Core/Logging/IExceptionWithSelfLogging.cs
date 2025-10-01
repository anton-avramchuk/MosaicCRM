using Microsoft.Extensions.Logging;

namespace MosaicCRM.Core.Logging;

public interface IExceptionWithSelfLogging
{
    void Log(ILogger logger);
}