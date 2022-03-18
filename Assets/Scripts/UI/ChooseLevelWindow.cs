using EventLayer;
using Level;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChooseLevelWindow : MonoBehaviour
    {
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
		}

		private void OnLevelButtonClick(int levelNumber)
		{
			LevelBus.ChoosenLevel.Publish(levelNumber);
		}
	}
}