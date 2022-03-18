using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Mobs
{
    public class MobView : MonoBehaviour
    {
        private Tween _tween;

        private UnityAction _onEndMoveCallback;

        public void Init(Vector2 endPoint, float speed)
		{
            var toEndPointDistance = Vector2.Distance(transform.position, endPoint);
            var duration = toEndPointDistance / speed;
            _tween = transform.DOMove(endPoint, duration)
                .SetEase(Ease.Linear)
                .OnComplete(() => _onEndMoveCallback?.Invoke());

            var scaleXMultiply = transform.position.x <= endPoint.x ? -1 : 1;
            var scaleTemp = transform.localScale;
            scaleTemp.x *= scaleXMultiply;
            transform.localScale = scaleTemp;
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