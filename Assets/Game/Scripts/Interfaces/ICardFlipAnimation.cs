using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Scripts.Enums;

namespace Game.Scripts.Abstract
{
    public interface ICardFlipAnimation
    {
        UniTask Play(ICard card, CardSide side);
    }
}