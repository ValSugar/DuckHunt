using System;

namespace Weapons
{
    [Serializable]
    public class WeaponModel
    {
        public string name;
        public int damage;
        public int maxShotsCount;
        public int currentShotsCount;

        public bool IsReadyToFire => currentShotsCount > 0;
    }
}
