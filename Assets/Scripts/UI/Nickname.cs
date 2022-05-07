using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Nickname : MonoBehaviour
{
    [SerializeField] private Text _nicknameText;

    private PhotonView _photonView;

    private void Start()
    {
        _photonView = GetComponent<PhotonView>();
        AddingNickname(); 
    }

    private void AddingNickname()
    {
        _nicknameText.text = _photonView.Owner.NickName;
    }
}
