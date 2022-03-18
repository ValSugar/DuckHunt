using EventLayer;
using Interfaces;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Weapons;

namespace Handlers
{
    public class InputHandler : MonoBehaviour, IPointerClickHandler
    {
		public void OnPointerClick(PointerEventData eventData)
		{
			WeaponController.Instance.TryFire();
		}
	}
}