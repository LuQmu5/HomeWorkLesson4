using System;
using System.Collections;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class EnemySpawner : IPause
{
    private float _spawnCooldown;
    private EnemySpawnerConfig _config;
    private EnemyFactory _enemyFactory;
    private bool _isPaused;

    [Inject]
    private void Construct(EnemyFactory enemyFactory, PauseHandler pauseHandler, ICoroutinePerformer coroutinePerformer, EnemySpawnerConfig config)
    {
        _config = config;
        _spawnCooldown = config.TimeBetweenSpawn;
        _enemyFactory = enemyFactory;
        pauseHandler.Add(this);
        coroutinePerformer.StartPerform(Spawn());

        Debug.Log("qq");
    }

    private IEnumerator Spawn()
    {
        float time = 0;

        while (true)
        {
            while (time < _spawnCooldown)
            {
                if(_isPaused == false)
                    time += Time.deltaTime;

                yield return null;  
            }

            Enemy enemy = _enemyFactory.Get((EnemyType)Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_config.EnemySpawnPoints[Random.Range(0, _config.EnemySpawnPoints.Count)]);
            time = 0;
        }
    }

    public void SetPause(bool isPause) => _isPaused = isPause;
}
