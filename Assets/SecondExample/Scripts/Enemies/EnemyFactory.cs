using System;
using System.IO;
using UnityEngine;
using Zenject;

public class EnemyFactory
{
    private const string ConfigsPath = "Enemies";

    private const string SmallConfig = "SmallEnemy";
    private const string MediumConfig = "MediumEnemy";
    private const string LargeConfig = "LargeEnemy";

    private EnemyConfig _small, _medium, _large;

    private IInstantiator _diContainer;

    public EnemyFactory(IInstantiator diContainer)
    {
        _diContainer = diContainer;
        Load();
    }

    public Enemy Get(EnemyType enemyType)
    {
        EnemyConfig config = GetConfig(enemyType);
        Enemy instance = _diContainer.InstantiatePrefabForComponent<Enemy>(config.Prefab);
        instance.Initialize(config.Health, config.Speed);
        return instance;
    }

    private EnemyConfig GetConfig(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Small:
                return _small;

            case EnemyType.Medium:
                return _medium;

            case EnemyType.Large:
                return _large;

            default:
                throw new ArgumentException(nameof(enemyType));
        }
    }

    private void Load()
    {
        _small = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, SmallConfig));
        _medium = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, MediumConfig));
        _large = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, LargeConfig));
    }
}
