using EventLayer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Weapons;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text _currentWeaponName;
        [SerializeField] private TMP_Text _shotsCount;
        [SerializeField] private TMP_Text _shotDucksCount;
        [SerializeField] private TMP_Text _flyingAwayDuckCount;
        [SerializeField] private Button _weaponSwapButton;
        [SerializeField] private Button _menuButton;

        private void Awake()
        {
            LevelBus.OnWeaponChanged += OnChagedWeaponName;
            LevelBus.OnShotsCountChanged += OnChangedShotsCount;
            LevelBus.OnShotDucksCountChanged += OnChangedShotDucksCount;
            LevelBus.OnFlyingAwayDucksCountChanged += OnChangedFlyingAwayDuckCount;

            _weaponSwapButton.onClick.AddListener(OnSwapWeaponButtonClick);
            _menuButton.onClick.AddListener(OnMenuButtonClick);
        }

        private void OnSwapWeaponButtonClick()
		{
            WeaponController.Instance.ChangeWeapon();
        }

        private void OnMenuButtonClick()
		{
            LevelMenuWindow.Instance.Show(false);
        }

        private void OnChagedWeaponName(string name) => _currentWeaponName.SetText(name);
        private void OnChangedShotsCount(int current, int max) => _shotsCount.SetText($"{current}/{max}");
        private void OnChangedShotDucksCount(int count) => _shotDucksCount.SetText($"{count}");
        private void OnChangedFlyingAwayDuckCount(int count) => _flyingAwayDuckCount.SetText($"{count}");

    }
}