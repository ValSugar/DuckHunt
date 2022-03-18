using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Mobs
{
    public class MobView : MonoBehaviour
    {
        private Transform _transform;
        private Tween _tween;

        private UnityAction _onEndMoveCallback;

        public void Init(Vector2 endPoint, float speed)
		{
            _transform = transform;

            var toEndPointDistance = Vector2.Distance(_transform.position, endPoint);
            var duration = toEndPointDistance / speed;
            _tween = _transform.DOMove(endPoint, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() => _onEndMoveCallback?.Invoke());

            var scaleXMultiply = _transform.position.x <= endPoint.x ? -1 : 1;
            var scaleTemp = _transform.localScale;
            scaleTemp.x *= scaleXMultiply;
            _transform.localScale = scaleTemp;
        }

        public void AddCallback(UnityAction onEndMoveCallback)
		{
            _onEndMoveCallback += onEndMoveCallback;
        }

		public void OnPointerClick(PointerEventData eventData)
		{
            _tween?.Kill();
        }
	}
}