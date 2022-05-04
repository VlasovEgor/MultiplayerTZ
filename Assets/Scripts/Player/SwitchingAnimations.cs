using Photon.Pun;
using UnityEngine;

public class SwitchingAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if(_photonView.IsMine==false)
        {
            return;
        }
    }

    public void CharacterMoving()
    {
        animator.SetBool("IsWalking", true);
    }

    public void CharacterStoped()
    {
        animator.SetBool("IsWalking", false);
    }
}
