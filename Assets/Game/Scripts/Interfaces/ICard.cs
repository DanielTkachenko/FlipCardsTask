using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts.Abstract
{
    public interface ICard
    {
        Transform Transform { get; }
        CardSide CurrentSide { get; }
        void SetContent(Texture2D texture);
        
        void SetSide(CardSide side);
    }
}