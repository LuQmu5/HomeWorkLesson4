using System;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    private const string CoroutinePerformerPath = "CoroutinePerformer";

    public override void InstallBindings()
    {
        BindLoader();
        BindInput();
        BindResources();
        BindCouroutinePerformer();
    }

    private void BindCouroutinePerformer()
    {
        Container.Bind<ICoroutinePerformer>().To<CoroutinePerformer>().FromComponentInNewPrefabResource(CoroutinePerformerPath).AsSingle();
    }

    private void BindResources()
    {
        Container.BindInstance(new Wallet(1000));
    }

    private void BindLoader()
    {
        Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        Container.Bind<SceneLoadMediator>().AsSingle();
    }

    private void BindInput()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
            Container.BindInterfacesAndSelfTo<MobileInput>().AsSingle();
        else
            Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
    }
}
