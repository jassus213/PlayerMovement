using UnityEngine;
using Zenject;


public class CameraView : MonoBehaviour, ICameraView
{
    private readonly SignalBus _signalBus;
    private ICameraPresenter _cameraPresenter;

    [SerializeField] private Transform _targetTransform;

    public CameraView(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void SetPresenter(ICameraPresenter cameraPresenter)
    {
        _cameraPresenter = cameraPresenter;
    }


    public void Move()
    {
        transform.position = new Vector3(_targetTransform.position.x + 2f, _targetTransform.position.y + 1f,
            _targetTransform.position.z);
    }
}