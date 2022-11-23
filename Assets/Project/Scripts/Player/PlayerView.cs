using UnityEngine;


[RequireComponent(typeof(Animator), typeof(Rigidbody), typeof(Transform))]
public class PlayerView : MonoBehaviour, IPlayerView
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidBody;

    [Header("Animations")]
    private string _jumpAnimation = "Jump";
    private readonly string _rollAnimation = "Roll";
    private readonly string _speedAnimator = "Speed";
    private readonly string _isGrounded = "IsGrounded";
    private readonly string _sprintAnimator = "Sprint";

    [Header("MovementStats")] private float _defaultSpeed;
    private readonly float _speed = 2;
    private readonly float _sprintSpeed = 5;
    private readonly float _rotationSpeed = 4;
    private readonly float _jumpForce = 7f;


    private IPlayerPresenter _playerPresenter;

    private void PlayAnim(string anim)
    {
        _animator.SetTrigger(anim);
    }


    public void SetPresenter(IPlayerPresenter playerPresenter)
    {
        _playerPresenter = playerPresenter;
    }

    public void Move(Vector3 direction, float speed)
    {
        var dir = new Vector3(direction.x * speed, _rigidBody.velocity.y, direction.z * speed);
        _rigidBody.velocity = dir;
    }

    public void Walk()
    {
        _defaultSpeed = _speed;
        _animator.SetFloat(_speedAnimator, _defaultSpeed);
    }

    public void Idle()
    {
        _animator.SetFloat(_speedAnimator, 0);
    }

    public void Jump()
    {
        _playerPresenter.IsGrounded(false);
        _animator.SetBool(_isGrounded, false);
        _rigidBody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
        PlayAnim(_jumpAnimation);
    }

    public void Sprint()
    {
        _defaultSpeed = _sprintSpeed;
        _animator.SetFloat(_speedAnimator, _defaultSpeed);
    }

    public void Roll()
    {
        if (_rigidBody.velocity.magnitude > 0)
            PlayAnim(_rollAnimation);
    }

    public void Rotation(Quaternion targetRotation)
    {
        var resultRotation =
            Quaternion.Slerp(_rigidBody.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime);
        _rigidBody.MoveRotation(resultRotation);
    }


    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.layer == 6)
        {
            _playerPresenter.IsGrounded(true);
            _animator.SetBool(_isGrounded, true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            _playerPresenter.IsGrounded(false);
            _animator.SetBool(_isGrounded, false);
        }
    }
}