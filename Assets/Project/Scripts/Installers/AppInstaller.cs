using UnityEngine;
using Zenject;

public class AppInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Application.targetFrameRate = 120;

        SignalBusInstaller.Install(Container);

    }
}   