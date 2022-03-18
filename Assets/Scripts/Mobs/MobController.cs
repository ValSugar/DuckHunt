using Interfaces;
using UnityEngine;
using UnityEngine.Events;

namespace Mobs
{
    public class MobController : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private MobModel _model;
        [SerializeField] private MobView _view;
         
        private event UnityAction<bool> _onDie;

        public void Init(Vector2 endPoint, UnityAction<bool> onDieCallback)
		{
            _onDie += onDieCallback;

            _view.Init(endPoint, _model.speed);
            _view.AddCallback(OnFlyingAway);
        }

        public void TakeDamage(int damage)
		{
            _model.health -= damage;
            if (_model.health > 0)
                return;

            Die();
		}

        private void Die()
		{
            _onDie?.Invoke(false);
            Destroy(gameObject);
		}

        private void OnFlyingAway()
		{
            _onDie?.Invoke(true);
            Destroy(gameObject);
        }
    }
}