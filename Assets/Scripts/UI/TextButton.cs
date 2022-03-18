using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI
{
    public class TextButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _label;

        public void Init(UnityAction callback, string text)
		{
            _button.onClick.AddListener(callback);
            _label.SetText(text);
		}
    }
}