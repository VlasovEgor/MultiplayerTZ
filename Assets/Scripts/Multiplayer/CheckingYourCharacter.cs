using UnityEngine;
using Photon.Pun;
public class CheckingYourCharacter : MonoBehaviour
{
    [Header("CharacterUI")]
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private GameObject _playerControllerCanvas;
    [SerializeField] private GameObject _playerButtonCanvas;
    [SerializeField] private GameObject _playerMoveButtonsController;

    private PhotonView _photonView;

    void Start()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (_photonView.IsMine == false)
        {
            _playerCamera.gameObject.SetActive(false);
            _playerControllerCanvas.SetActive(false);
            _playerButtonCanvas.SetActive(false);
            _playerMoveButtonsController.SetActive(false);
            return;
        }
    }
}
