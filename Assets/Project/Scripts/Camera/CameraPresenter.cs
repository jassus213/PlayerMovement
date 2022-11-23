using Zenject;

public class CameraPresenter : ICameraPresenter, IInitializable, IFixedTickable
{
    private ICameraView _cameraView;

    public CameraPresenter(ICameraView cameraView)
    {
        _cameraView = cameraView;
    }

    public void Initialize()
    {
        _cameraView.SetPresenter(this);
    }

    public void FixedTick()
    {
        _cameraView.Move();
    }
}