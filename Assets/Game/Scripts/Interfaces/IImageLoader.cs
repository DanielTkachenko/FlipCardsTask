using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Enums;

namespace Game.Scripts.ImageLoaders
{
    public interface IImageLoader
    {
        UniTask Load(IReadOnlyList<Card> cards, string url, CancellationToken cancellationToken = default);
    }
}