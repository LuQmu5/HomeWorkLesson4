using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Zenject;

public class GameInstaller : MonoInstaller 
{
    [SerializeField] private Character _characterPrefab;
    [SerializeField] private Transform _characterSpawnPoint;
    [SerializeField] private CharacterConfig _config;

    public override void InstallBindings()
    {
        Character character = Container.InstantiatePrefabForComponent<Character>(_characterPrefab, _characterSpawnPoint.position, Quaternion.identity, null);
        Container.Bind<CharacterConfig>().FromInstance(_config).AsSingle();
        Container.BindInstance(new CharacterStats(_config.StartLevel, _config.StartMaxHealth));

        Container.BindInstance(new GameManagement(characterStats, _character, _refreshableObjects));
        Container.BindInstance(new GameManagementMediator(_gameOverPanel, _character, gameManagement));
    }
}
