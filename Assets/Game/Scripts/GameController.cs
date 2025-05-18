using System;
using System.Collections.Generic;
using Game.Scripts;
using Game.Scripts.Abstract;
using Game.Scripts.Enums;
using Game.Scripts.ImageLoaders;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private string _downloadUrl;
    [SerializeField] MainCanvas _mainCanvas;
    
    private IReadOnlyList<ICard> _cards;
    private Dictionary<LoadType, IImageLoader> _imageLoaders;
    private IImageDownloader _imageDownloader;
    private ICardFlipAnimation _cardFlipAnimation;

    private void Awake()
    {
        _cards = _mainCanvas.Cards;
        
        _imageDownloader = new ImageDownloader();
        _cardFlipAnimation = new CardFlipAnimation();
        _imageLoaders = new Dictionary<LoadType, IImageLoader>()
        {
            { LoadType.AllAtOnce , new AllAtOnceImageLoader(_imageDownloader, _cardFlipAnimation)},
            { LoadType.WhenReady, new WhenReadyImageLoader(_imageDownloader, _cardFlipAnimation)},
            { LoadType.OneByOne, new OneByOneImageLoader(_imageDownloader, _cardFlipAnimation)}
        };
    }

    private void Start()
    {
        _mainCanvas.loadButton.onClick.AddListener(LoadButtonClickHandler);
        _mainCanvas.cancelButton.onClick.AddListener(CancelButtonClickHandler);
    }

    private void LoadButtonClickHandler()
    {
        
    }

    private void CancelButtonClickHandler()
    {
        
    }
}
