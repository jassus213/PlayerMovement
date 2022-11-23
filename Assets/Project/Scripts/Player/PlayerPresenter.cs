using Zenject;
using UnityEngine;
using IInitializable = Zenject.IInitializable;


public class PlayerPresenter : IPlayerPresenter, IInitializable, IFixedTickable
{
    [Header("Zenject")] private readonly SignalBus _signalBus;
    private readonly IPlayerView _playerView;
    private readonly PlayerInputState _inputState;


    [Header("MovementStats")] private float _speed = 2;
    private float _sprintSpeed = 5;
    private Vector3 _direction;

    [Header("Other")] private bool _isGrounded = false;


    public PlayerPresenter(SignalBus signalBus, IPlayerView playerView, PlayerInputState inputState)
    {
        _signalBus = signalBus;
        _playerView = playerView;
        _inputState = inputState;
    }


    public void IsGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }


    public void Initialize()
    {
        _playerView.SetPresenter(this);
    }


    public void FixedTick()
    {
        _direction = new Vector3(-_inputState.IsMovingVertical, 0f, _inputState.IsMovingHorizontal);

        if (_inputState.IsJumping)
        {
            _playerView.Jump();
        }

        if (_inputState.IsRolling)
        {
            _playerView.Roll();
        }

        if (_direction == Vector3.zero)
        {
            _playerView.Idle();
            return;
        }

        var targetRot = Quaternion.LookRotation(_direction, Vector3.up);
        _playerView.Rotation(targetRot);

        if (_inputState.IsSprinting)
        {
            _playerView.Move(_direction, _sprintSpeed);
            _playerView.Sprint();
        }
        else
        {
            _playerView.Move(_direction, _speed);
            _playerView.Walk();
        }
    }
}