using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Level
{
    [CreateAssetMenu(fileName = "LevelsHolder", menuName = "Holders/LevelsHolder")]
    public class LevelsHolder : ScriptableObject
    {
        [SerializeField] private LevelModel[] _levelModels;

        public int LevelModelsCount => _levelModels.Length;

        public LevelModel GetLevelModelByIndex(int index) => _levelModels[index];
    }

    [Serializable]
    public class LevelModel
	{
        public RoundModel[] rounds;
    }
}