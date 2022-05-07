using UnityEngine;

public class MoveCharacterWithButtons : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;

    private bool _isMoving = false;

    private void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0)
        {   

            _characterMovement.MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            if (_isMoving == false)
            {
                _characterMovement.PlayerMoved();
                _isMoving = true;
            }
        }
        else
        {
            if (_isMoving == true)
            {
                _characterMovement.PlayerStopped();
                _isMoving = false;
            }
        }
    }

    private void Rotation()
    {   
        if(Input.GetAxis("Mouse X")!=0)
        {
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime;
            _characterMovement.RotateCharacter(new Vector3(0, mouseX * 50, 0));
        }
    }
}
