using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Abstract;
using UnityEngine;
using UnityEngine.Networking;

namespace Game.Scripts
{
    public class ImageDownloader : IImageDownloader
    {
        public async UniTask<Texture2D> Load(string url, CancellationToken cancellationToken)
        {
            using var request = UnityWebRequestTexture.GetTexture(url);
        
            await request.SendWebRequest().WithCancellation(cancellationToken);

            return request.result == UnityWebRequest.Result.Success ? DownloadHandlerTexture.GetContent(request) : null;
        }
    }
}