using System.Collections.Generic;
using RBT.CodeBase.Runtime.Gameplay.Logic.Battle.GameCondition;
using RBT.CodeBase.Runtime.Gameplay.Logic.Characters;
using RBT.CodeBase.Runtime.Gameplay.Logic.Spawn;
using RBT.CodeBase.Runtime.Infrastructure.Services;
using RBT.CodeBase.Runtime.Infrastructure.Services.TimerManager;
using RBT.CodeBase.Runtime.UI;
using UnityEngine;
using Zenject;

namespace RBT.CodeBase.Runtime.Gameplay.Logic.Battle
{
  public class Battle : IBattle, ITickable
  {
    private readonly ITimerManager _timerManager;
    private readonly ITimeUpdater _timeUpdater;
    private readonly EnemySpawner _enemySpawner;
    private readonly PauseService _pauseService;
    private readonly ICharacterRegistry _registry;

    private BattleConditions _battleConditions;
    private HUDMediator _hudMediator;
    private bool _isGameOver;


    public Battle(
      ICharacterRegistry registry,
      ITimerManager timerManager,
      ITimeUpdater timeUpdater,
      EnemySpawner enemySpawner,
      PauseService pauseService)
    {
      _registry = registry;
      _enemySpawner = enemySpawner;
      _pauseService = pauseService;
      _timerManager = timerManager;
      _timeUpdater = timeUpdater;
    }

    public void StartBattle(HUDMediator hudMediator)
    {
      _hudMediator = hudMediator;
      NextWave();
    }

    public void PauseBattle() =>
      _pauseService.PauseGame();

    public void ContinueBattle()
    {
      NextWave();
      _pauseService.ContinueGame();
    }

    public void Tick()
    {
      float deltaTime = Time.deltaTime;
      _timeUpdater.Update(deltaTime);
    }

    private void NextWave()
    {
      float timeOutSec = _enemySpawner.GetWaveDurations();

      _battleConditions = new BattleConditions(
        new List<ICondition> { new TimeOutCondition(_timerManager, timeOutSec) },
        new List<ICondition> { new AllEnemiesDeadCondition(_registry) });

      _battleConditions.ConditionCompleted += GameOver;
      _hudMediator.SetTimeOut(timeOutSec);
      _hudMediator.SetCurrentWave(_enemySpawner.CurrentWave);
      _enemySpawner.NextWave();
    }

    private void GameOver(bool isPlayerWin)
    {
      _battleConditions.ConditionCompleted -= GameOver;
      _battleConditions.CleanUp();

      if (isPlayerWin)
        _hudMediator.ShowWin();
      else
        _hudMediator.ShowLose();

      if (_enemySpawner.WaveCount == _enemySpawner.CurrentWave)
        _hudMediator.HideContinueButton();

      PauseBattle();
    }
  }
}