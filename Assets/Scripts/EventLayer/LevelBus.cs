using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventLayer
{
    public static class LevelBus
    {
        public static State<int> ChoosenLevel;

        public static UnityAction<int> OnStartNextStage;
        public static UnityAction<int, int> OnShotsCountChanged;
        public static UnityAction<string> OnWeaponChanged;

        public static UnityAction<int> OnShotDucksCountChanged;
        public static UnityAction<int> OnFlyingAwayDucksCountChanged;

        static LevelBus()
		{
            ChoosenLevel = new State<int>();
		}
    }
}
