using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller 
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Transform _characterSpawnPoint;
    [SerializeField] private CharacterConfig _config;

    public override void InstallBindings()
    {
        Container.Bind<CharacterConfig>().FromInstance(_config).AsSingle();
        Container.BindInstance(new CharacterStats(_config.StartLevel, _config.StartMaxHealth));
        Character character = Container.InstantiatePrefabForComponent<Character>(_characterPrefab, _characterSpawnPoint.position, Quaternion.identity, null);
        Container.BindInstance(character);

        /*
        Container.Bind<GameManagement>().AsSingle();
        Container.Bind<GameManagementMediator>().AsSingle();
        */
    }
}
