using UnityEngine;

public interface IPlayerView
{
    void SetPresenter(IPlayerPresenter playerPresenter);
    void Move(Vector3 direction, float speed);
    void Jump();
    void Sprint();
    void Roll();
    void Walk();
    void Idle();
    void Rotation(Quaternion targetRotation);
}