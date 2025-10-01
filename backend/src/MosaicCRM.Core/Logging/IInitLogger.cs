using Microsoft.Extensions.Logging;

namespace MosaicCRM.Core.Logging;

public interface IInitLogger<out T> : ILogger<T>
{
    public List<InitLogEntry> Entries { get; }
}