using System;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Gravity))]
public class CharacterMovement : MonoBehaviour
{
    public event Action Moved;
    public event Action Stopped;

    [Header("Character movement stats")]
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    [Header("Character components")]
    private CharacterController _characterController;

    private Gravity _gravity;


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _gravity = GetComponent<Gravity>();
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        moveDirection.y = _gravity.GravityHandling();
        Vector3 move = transform.TransformDirection(moveDirection);
        _characterController.Move(move * _moveSpeed * Time.deltaTime);
    }

    public void RotateCharacter(Vector3 rotateDirection)
    {
        transform.Rotate(rotateDirection * _rotateSpeed);
    }

    public void PlayerMoved()
    {
        Moved?.Invoke();
    }

    public void PlayerStopped()
    {
        Stopped?.Invoke();
    }
}