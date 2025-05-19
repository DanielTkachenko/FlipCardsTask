using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
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
    private Dictionary<string, IImageLoader> _imageLoaders;
    private IImageDownloader _imageDownloader;
    private ICardFlipAnimation _cardFlipAnimation;
    CancellationTokenSource _cancellationTokenSource;

    private void Awake()
    {
        _imageDownloader = new ImageDownloader();
        _cardFlipAnimation = new CardFlipAnimation();
        _imageLoaders = new Dictionary<string, IImageLoader>()
        {
            { "All at once" , new AllAtOnceImageLoader(_imageDownloader, _cardFlipAnimation)},
            { "When ready", new WhenReadyImageLoader(_imageDownloader, _cardFlipAnimation)},
            { "One by one", new OneByOneImageLoader(_imageDownloader, _cardFlipAnimation)}
        };
    }

    private void Start()
    {
        _cards = _mainCanvas.Cards;
        
        _mainCanvas.loadButton.onClick.AddListener(LoadButtonClickHandler);
        _mainCanvas.cancelButton.onClick.AddListener(CancelButtonClickHandler);
        
        SetUIInteractableState(true);
    }

    private void LoadButtonClickHandler()
    {
        LoadImages().Forget();
    }

    private void CancelButtonClickHandler()
    {
        _cancellationTokenSource?.Cancel();
    }

    private async UniTaskVoid LoadImages()
    {
        SetUIInteractableState(false);
        
        var loaderOption =_mainCanvas.Dropdown.options[_mainCanvas.Dropdown.value].text;
        var loader = _imageLoaders[loaderOption];

        try
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            var isCancelled = await loader
                .Load(_cards, _downloadUrl, _cancellationTokenSource.Token)
                .SuppressCancellationThrow();

            if (isCancelled)
            {
                Debug.Log("Operation was cancelled");
            }
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }
        finally
        {
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }
        
        SetUIInteractableState(true);
    }

    private void SetUIInteractableState(bool state)
    {
        _mainCanvas.Dropdown.interactable = state;
        _mainCanvas.loadButton.interactable = state;
        _mainCanvas.cancelButton.interactable = !state;
    }
}
