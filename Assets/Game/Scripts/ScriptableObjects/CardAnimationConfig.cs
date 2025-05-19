using UnityEngine;

namespace Game.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Configs/CardAnimationConfig", fileName = "CardAnimationConfig")]
    public class CardAnimationConfig : ScriptableObject
    {
        public float flipAnimationDuration;
    }
}