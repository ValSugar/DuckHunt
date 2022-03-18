using EventLayer;
using Level;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChooseLevelWindow : MonoBehaviour
    {
		[SerializeField] private TMP_Text _levelIndexLabel;
		[SerializeField] private Transform _content;
		[SerializeField] private Button _backButton;
        [SerializeField] private TextButton _levelButtonPrefab;
        [SerializeField] private LevelsHolder _levelsHolder;

		private void Awake()
		{
			for (var i = 0; i < _levelsHolder.LevelModelsCount; i++)
			{
				var index = i;
				Instantiate(_levelButtonPrefab, _content)
					.Init(() => OnLevelButtonClick(index), index.ToString());
			}

			_backButton.onClick.AddListener(() => gameObject.SetActive(false));

			_levelIndexLabel.SetText($"Choosen Level: {LevelBus.ChoosenLevel.Value}");
		}

		private void OnLevelButtonClick(int levelNumber)
		{
			_levelIndexLabel.SetText($"Choosen Level: {levelNumber}");
			LevelBus.ChoosenLevel.Publish(levelNumber);
		}
	}
}