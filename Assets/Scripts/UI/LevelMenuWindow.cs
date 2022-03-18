using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utilities;

namespace UI
{
    public class LevelMenuWindow : Singleton<LevelMenuWindow>
    {
        [SerializeField] private GameObject _gameOverTitle;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _newGameButton;
        [SerializeField] private Button _mainMenuButton;

		protected override void OnAwake()
		{
            base.OnAwake();
            _resumeButton.onClick.AddListener(() => gameObject.SetActive(false));
            _newGameButton.onClick.AddListener(() => SceneManager.LoadScene((int)SceneEnum.Battleground));
            _mainMenuButton.onClick.AddListener(() => SceneManager.LoadScene((int)SceneEnum.MainMenu));
            gameObject.SetActive(false);
        }

		public void Show(bool isGameOver)
		{
            gameObject.SetActive(true);
            _gameOverTitle.SetActive(isGameOver);
            _resumeButton.gameObject.SetActive(!isGameOver);
        }

        private void OnEnable()
        {
            Time.timeScale = 0f;    //Better to make a single time controller
        }

        private void OnDisable()
        {
            Time.timeScale = 1f;    //Better to make a single time controller
        }
    }
}