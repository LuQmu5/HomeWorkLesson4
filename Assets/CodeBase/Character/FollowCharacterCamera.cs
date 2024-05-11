using UnityEngine;
using Cinemachine;
using Zenject;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class FollowCharacterCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineCamera;

    [Inject]
    public void Construct(Character character)
    {
        _cinemachineCamera.Follow = character.transform;
    }
}