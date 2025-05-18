using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Scripts.Abstract;
using Game.Scripts.Enums;
using UnityEngine;

namespace Game.Scripts
{
    public class CardFlipAnimation : ICardFlipAnimation
    {
        private float animationTime = 0.6f;
        private Vector3 targetRotation = new Vector3(0, 90, 0);
        
        public async UniTask Play(ICard card, CardSide side)
        {
            if (card.CurrentSide == side) return;

            card.Transform.DORotate(targetRotation, animationTime);
            card.SetSide(side);
            card.Transform.DORotate(Vector3.zero, animationTime);
        }
    }
}