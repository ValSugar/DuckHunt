using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
		[SerializeField] private ChooseLevelWindow _chooseLevelWindow;
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _chooseLevelButton;

		private void Awake()
		{
			_startGameButton.onClick.AddListener(StartGame);
			_chooseLevelButton.onClick.AddListener(EnableChooseLevelWindow);
		}

		private void StartGame()
		{
			SceneManager.LoadScene((int)SceneEnum.Battleground);
		}

		private void EnableChooseLevelWindow()
		{
			_chooseLevelWindow.gameObject.SetActive(true);
		}
	}
}