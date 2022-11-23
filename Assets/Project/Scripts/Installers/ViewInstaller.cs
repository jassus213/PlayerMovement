using System;
using UnityEngine;
using Zenject;

[Serializable]
public class ViewInstaller : MonoInstaller
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private CameraView _cameraView;
    public override void InstallBindings()
    {
        GameSceneInstaller.Install(Container);

        Container.BindInterfacesAndSelfTo<PlayerView>().FromInstance(_playerView);
        Container.BindInterfacesAndSelfTo<CameraView>().FromInstance(_cameraView);
    }
}