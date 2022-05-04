using UnityEngine;

public class JoystickForCamera : JoystickHandler
{
    [SerializeField] private CharacterMovement _characterMovement;

    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
        {
            _characterMovement.RotateCharacter(new Vector3(0, _inputVector.x/3, 0));
        }
    }
}
