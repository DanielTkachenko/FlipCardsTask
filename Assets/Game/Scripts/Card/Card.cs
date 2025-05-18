using System;
using Game.Scripts.Abstract;
using Game.Scripts.Enums;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour, ICard
{
    [Header("UI Elements")]
    [SerializeField] private Image background;
    [SerializeField] private RawImage content;
    [Header("Properties")]
    [SerializeField] private Sprite frontSprite;
    [SerializeField] private Sprite backSprite;

    private CardSide _currentSide;

    public CardSide CurrentSide => _currentSide;
    public Transform Transform => transform;

    private void Awake()
    {
        SetSide(CardSide.Back);
    }

    private void OnDestroy()
    {
        if (content.texture != null)
        {
            Destroy(content.texture);
        }
    }

    public void SetContent(Texture2D texture)
    {
        if (content.texture != null)
        {
            Destroy(content.texture);
        }
        
        content.texture = texture;
    }

    public void SetSide(CardSide side)
    {
        _currentSide = side;

        background.sprite = _currentSide == CardSide.Front ? frontSprite : backSprite;
    }
}
