using Mobs;
using System;

namespace Level
{
    [Serializable]
    public class RoundModel
    {
        public StageModel[] stages;
        public float startStageDelay;

        [Serializable]
        public class StageModel
		{
            public MobController mobPrefab;
            public int mobsCount;
        }
    }
}