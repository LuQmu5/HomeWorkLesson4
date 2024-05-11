using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller 
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Transform _characterSpawnPoint;
    [SerializeField] private CharacterConfig _config;
    [SerializeField] private GameOverPanel _gameOverPanel;
    [SerializeField] private RefreshableObject[] _refreshableObjects;

    public override void InstallBindings()
    {
        Container.Bind<CharacterConfig>().FromInstance(_config).AsSingle();
        Container.BindInstance(new CharacterStats(_config.StartLevel, _config.StartMaxHealth)).AsSingle();

        Character character = Container.InstantiatePrefabForComponent<Character>(_characterPrefab, _characterSpawnPoint.position, Quaternion.identity, null);
        Container.BindInstance(character).AsSingle();

        Container.BindInstance(new GameManagement( , character, _refreshableObjects)).AsSingle();
        Container.BindInstance(new GameManagementMediator(_gameOverPanel, character, )).AsSingle();
    }
}
