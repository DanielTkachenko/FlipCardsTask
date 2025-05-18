using System;
using System.Collections.Generic;
using Game.Scripts.Abstract;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts
{
    public class MainCanvas : MonoBehaviour
    {
        public TMP_Dropdown Dropdown => _dropdown;
        public Button loadButton => _loadButton;
        public Button cancelButton => _cancelButton;
        
        public IReadOnlyList<ICard> Cards => _cards;

        [SerializeField] private Transform _cardsContainer;
        [Header("UI Elements")]
        [SerializeField] private TMP_Dropdown _dropdown;
        [SerializeField] private Button _loadButton;
        [SerializeField] private Button _cancelButton;

        private IReadOnlyList<ICard> _cards;
        
        private void Awake() => _cards = _cardsContainer.GetComponentsInChildren<ICard>();
    }
}