using UnityEngine;
using Zenject;

public class PlayerInputHandler : IFixedTickable
{
    readonly PlayerInputState _inputState;

    public PlayerInputHandler(PlayerInputState inputState)
    {
        _inputState = inputState;
    }

    public void FixedTick()
    {
        _inputState.IsMovingHorizontal = Input.GetAxis("Horizontal");
        _inputState.IsMovingVertical = Input.GetAxis("Vertical");

        _inputState.IsSprinting = Input.GetKey(KeyCode.LeftShift);
        _inputState.IsJumping = Input.GetKeyDown(KeyCode.Space);
        _inputState.IsRolling = Input.GetKeyDown(KeyCode.LeftAlt);
    }
}