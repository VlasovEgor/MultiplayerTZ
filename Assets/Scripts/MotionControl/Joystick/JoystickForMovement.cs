using UnityEngine;

public class JoystickForMovement : JoystickHandler
{
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private SwitchingAnimations _switchingAnimations;
    
    private void Update()
    { 
        Movement();
    }

    private void Movement()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
        {
            _switchingAnimations.CharacterMoving();
            _characterMovement.MoveCharacter(new Vector3(_inputVector.x, 0, _inputVector.y));
        }
        else
        {
            _switchingAnimations.CharacterStoped();
        }
    }
}
