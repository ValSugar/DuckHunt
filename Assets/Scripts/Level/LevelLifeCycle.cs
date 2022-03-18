using EventLayer;
using System.Collections;
using UI;
using UnityEngine;

namespace Level
{
    public class LevelLifeCycle : MonoBehaviour
    {
		[SerializeField] private LevelsHolder _levelsHolder;
		[SerializeField] private Transform _minMobsStartPoint;
		[SerializeField] private Transform _maxMobsStartPoint;
		[SerializeField] private Transform _mobsEndPoint;
		[SerializeField] private float _endPointXRange;

		private RoundModel[] _rounds;

		private int _roundIndex;
        private int _stageIndex;
		private int _mobsDieCount;

		private int _totalMobsShotCount;
		private int _totalMobsFlyingAwayCount;

		private RoundModel _currentRound;

		public void Awake()
		{
			_rounds = _levelsHolder.GetLevelModelByIndex(LevelBus.ChoosenLevel.Value).rounds;
			StartRound();
		}

		private void StartRound()
		{
			_stageIndex = 0;
			_currentRound = _rounds[_roundIndex];
			StartStage();
		}

		private void StartStage()
		{
			_mobsDieCount = 0;
			StartCoroutine(StageCoroutine());
			LevelBus.OnStartNextStage?.Invoke(_stageIndex);
		}

		private IEnumerator StageCoroutine()
		{
			yield return new WaitForSeconds(_currentRound.startStageDelay);
			var currentStage = _currentRound.stages[_stageIndex];
			for (var i = 0; i < currentStage.mobsCount; i++)
			{
				var startPoint = new Vector2(
					Random.Range(_minMobsStartPoint.position.x, _maxMobsStartPoint.position.x), 
					Random.Range(_minMobsStartPoint.position.y, _maxMobsStartPoint.position.y));

				var mob = Instantiate(currentStage.mobPrefab, startPoint, Quaternion.identity);

				var randomEndPoint = _mobsEndPoint.position;
				randomEndPoint.x += Random.Range(-_endPointXRange, _endPointXRange);
				mob.Init(randomEndPoint, OnMobDie);
			}
		}

		private void OnMobDie(bool isFlyingAway)
		{
			if (isFlyingAway)
				LevelBus.OnFlyingAwayDucksCountChanged?.Invoke(++_totalMobsFlyingAwayCount);
			else
				LevelBus.OnShotDucksCountChanged?.Invoke(++_totalMobsShotCount);

			if (++_mobsDieCount < _currentRound.stages[_stageIndex].mobsCount)
				return;

			if (++_stageIndex < _currentRound.stages.Length)
			{
				StartStage();
				return;
			}

			if (++_roundIndex < _rounds.Length)
			{
				StartRound();
				return;
			}

			LevelMenuWindow.Instance.Show(true);
		}
	}
}