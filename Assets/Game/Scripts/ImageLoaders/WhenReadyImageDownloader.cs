using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Abstract;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.ImageLoaders
{
    public class WhenReadyImageLoader : IImageLoader
    {
        private readonly IImageDownloader _imageDownloader;
        private readonly ICardFlipAnimation _cardFlipAnimation;

        public WhenReadyImageLoader(IImageDownloader imageDownloader, ICardFlipAnimation cardFlipAnimation)
        {
            _imageDownloader = imageDownloader;
            _cardFlipAnimation = cardFlipAnimation;
        }
        
        public async UniTask Load(IReadOnlyList<ICard> cards, string url, CancellationToken cancellationToken = default)
        {
            await UniTask.WhenAll(cards.Select(async card =>
            {
                var downloadedTexture = _imageDownloader.Load(url, cancellationToken);

                await _cardFlipAnimation.Play(card, CardSide.Back);
                card.SetContent(await downloadedTexture);
                await _cardFlipAnimation.Play(card, CardSide.Front);
            }));
        }
    }
}