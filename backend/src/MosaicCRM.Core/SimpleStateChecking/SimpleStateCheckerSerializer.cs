using System.Text.Json.Nodes;
using MosaicCRM.Core.DependencyInjection;

namespace MosaicCRM.Core.SimpleStateChecking;

[Export(LifetimeType.Singleton, typeof(ISimpleStateCheckerSerializer))]
public class SimpleStateCheckerSerializer :
    ISimpleStateCheckerSerializer
{
    private readonly IEnumerable<ISimpleStateCheckerSerializerContributor> _contributors;

    public SimpleStateCheckerSerializer(IEnumerable<ISimpleStateCheckerSerializerContributor> contributors)
    {
        _contributors = contributors;
    }

    public string? Serialize<TState>(ISimpleStateChecker<TState> checker)
        where TState : IHasSimpleStateCheckers<TState>
    {
        foreach (var contributor in _contributors)
        {
            var result = contributor.SerializeToJson(checker);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }

    public ISimpleStateChecker<TState>? Deserialize<TState>(JsonObject jsonObject, TState state)
        where TState : IHasSimpleStateCheckers<TState>
    {
        foreach (var contributor in _contributors)
        {
            var result = contributor.Deserialize(jsonObject, state);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}