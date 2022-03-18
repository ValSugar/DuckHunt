using EventLayer;
using Interfaces;
using UnityEngine;
using Utilities;

namespace Weapons
{
    public class WeaponController : Singleton<WeaponController>
    {
		[SerializeField] private LayerMask _mobLayer;
		[SerializeField] private WeaponModel[] _models;

		private int _modelIndex;

		private WeaponModel CurrentWeaponModel => _models[_modelIndex];

		private void Start()
		{
			_modelIndex = 0;

			LevelBus.OnShotsCountChanged?.Invoke(CurrentWeaponModel.currentShotsCount, CurrentWeaponModel.maxShotsCount);
			LevelBus.OnWeaponChanged?.Invoke(CurrentWeaponModel.name);
			LevelBus.OnStartNextStage += Reload;
		}

		public void TryFire()
		{
			if (!CurrentWeaponModel.IsReadyToFire)
				return;

			--CurrentWeaponModel.currentShotsCount;
			LevelBus.OnShotsCountChanged?.Invoke(CurrentWeaponModel.currentShotsCount, CurrentWeaponModel.maxShotsCount);

			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			var hitInfo = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, _mobLayer);

			if (hitInfo.collider == null
				|| !hitInfo.collider.TryGetComponent(out ITakeDamage damageTaker))
				return;

			damageTaker.TakeDamage(CurrentWeaponModel.damage);
		}

		private void Reload(int stage)
		{
			foreach (var model in _models)
				model.currentShotsCount = model.maxShotsCount;

			LevelBus.OnShotsCountChanged?.Invoke(CurrentWeaponModel.currentShotsCount, CurrentWeaponModel.maxShotsCount);
		}

		public void ChangeWeapon()
		{
			if (++_modelIndex >= _models.Length)
				_modelIndex = 0;

			LevelBus.OnShotsCountChanged?.Invoke(CurrentWeaponModel.currentShotsCount, CurrentWeaponModel.maxShotsCount);
			LevelBus.OnWeaponChanged?.Invoke(CurrentWeaponModel.name);
		}
	}
}
