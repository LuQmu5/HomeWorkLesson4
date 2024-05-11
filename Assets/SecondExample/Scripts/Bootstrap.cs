using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private PauseHandler _pauseHandler;

    [Inject]
    private void Construct(PauseHandler pauseHandler, EnemySpawner enemySpawner)
    {
        _pauseHandler = pauseHandler;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
            _pauseHandler.SetPause(true);

        if(Input.GetKeyUp(KeyCode.F))
            _pauseHandler.SetPause(false);
    }
}
