using UnityEngine;

public class JoystickForMovement : JoystickHandler
{
    [SerializeField] private CharacterMovement _characterMovement;

    private bool _isMoving=false;

    private void Update()
    { 
        Movement();
    }

    private void Movement()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
        {
            _characterMovement.MoveCharacter(new Vector3(_inputVector.x, 0, _inputVector.y));
            if(_isMoving==false)
            {
                _characterMovement.PlayerMoved();
                _isMoving = true;
            }
        }
        else
        {   
            if(_isMoving == true)
            {
                _characterMovement.PlayerStopped();
                _isMoving = false;
            }
           
        }
    }
}
