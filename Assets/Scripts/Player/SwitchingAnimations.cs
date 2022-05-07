using Photon.Pun;
using UnityEngine;

public class SwitchingAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private CharacterMovement _characterMovement;

    private void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _characterMovement.Stopped += CharacterStoped;
        _characterMovement.Moved += CharacterMoving;
    }

    public void CharacterMoving()
    {
        animator.SetBool("IsWalking", true);
    }

    public void CharacterStoped()
    {
        animator.SetBool("IsWalking", false);
    }

    private void OnDestroy()
    {
        _characterMovement.Stopped -= CharacterStoped;
        _characterMovement.Moved -= CharacterMoving;
    }
}
