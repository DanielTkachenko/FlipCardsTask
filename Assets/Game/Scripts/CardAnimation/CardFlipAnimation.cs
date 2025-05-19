using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Game.Scripts.Abstract;
using Game.Scripts.Enums;
using Game.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Scripts
{
    public class CardFlipAnimation : ICardFlipAnimation
    {
        private float animationDuration = 1f;
        private Vector3 targetRotation = new Vector3(0, 90, 0);

        public CardFlipAnimation(CardAnimationConfig config)
        {
            animationDuration = config.flipAnimationDuration;
        }
        
        public async UniTask Play(ICard card, CardSide side)
        {
            if (card.CurrentSide == side) return;

            await card.Transform.DORotate(targetRotation, animationDuration / 2);
            card.SetSide(side);
            await card.Transform.DORotate(Vector3.zero, animationDuration / 2);
        }
    }
}