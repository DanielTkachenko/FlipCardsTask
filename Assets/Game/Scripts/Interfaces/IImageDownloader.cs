using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Scripts.Abstract
{
    public interface IImageDownloader
    {
        UniTask<Texture2D> Load(string url, CancellationToken cancellationToken);
    }
}