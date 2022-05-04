using UnityEngine;

public class MoveCharacterWithButtons : MonoBehaviour
{
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private SwitchingAnimations _switchingAnimations;
    

    private void Update()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical") != 0)
        {   
            _switchingAnimations.CharacterMoving();
            _characterMovement.MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        }
        else
        {
            _switchingAnimations.CharacterStoped();
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
