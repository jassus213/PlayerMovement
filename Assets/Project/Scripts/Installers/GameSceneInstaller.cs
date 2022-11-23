using Zenject;

public class GameSceneInstaller : Installer<GameSceneInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerPresenter>().AsSingle();
        Container.BindInterfacesAndSelfTo<CameraPresenter>().AsSingle();

        Container.Bind<PlayerInputState>().AsSingle();
        Container.BindInterfacesAndSelfTo<PlayerInputHandler>().AsSingle();
    }
}