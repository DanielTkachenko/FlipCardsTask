using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Abstract;

namespace Game.Scripts.ImageLoaders
{
    public interface IImageLoader
    {
        UniTask Load(IReadOnlyList<ICard> cards, string url, CancellationToken cancellationToken = default);
    }
}