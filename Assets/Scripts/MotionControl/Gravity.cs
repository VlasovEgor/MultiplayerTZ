using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private float _gravityForce=10;
    private CharacterController _characterController;
    private float _currentAttractionCharacter;
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public float GravityHandling()
    {
        if (_characterController.isGrounded == false)
        {
            _currentAttractionCharacter -= _gravityForce * Time.deltaTime;
            return _currentAttractionCharacter;
        }
        else
        {
            _currentAttractionCharacter = 0;
            return _currentAttractionCharacter;
        }

    }
}
