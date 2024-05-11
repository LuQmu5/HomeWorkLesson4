using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller
{
    private const string ConfigPath = "Enemies/SpawnerConfig";

    public override void InstallBindings()
    {
        EnemySpawnerConfig config = Resources.Load<EnemySpawnerConfig>(ConfigPath);

        Container.Bind<EnemySpawner>().AsSingle();
        Container.Bind<EnemyFactory>().AsSingle();
        Container.Bind<EnemySpawnerConfig>().FromInstance(config).AsSingle();
    }
}
