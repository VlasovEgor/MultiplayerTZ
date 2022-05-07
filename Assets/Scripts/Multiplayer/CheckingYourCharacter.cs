using UnityEngine;
using Photon.Pun;
public class CheckingYourCharacter : MonoBehaviour
{
    [Header("CharacterUI")]
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private GameObject _playerControllerCanvas;
    [SerializeField] private GameObject _playerButtonCanvas;
    [SerializeField] private GameObject _playerMoveButtonsController;
    [SerializeField] private GameObject _nickname;

    private PhotonView _photonView;
    private GameManager _gameManager;

    
    void Start()
    {
        _photonView = GetComponent<PhotonView>();

        _gameManager = FindObjectOfType<GameManager>();
        _gameManager.Connected += PlayerOnConnected;
        _gameManager.PlayerConnected();
    }
    
    private void PlayerOnConnected()
    {
        if (_photonView.IsMine == false)
        {
            _playerCamera.gameObject.SetActive(false);
            _playerControllerCanvas.SetActive(false);
            _playerButtonCanvas.SetActive(false);
            _playerMoveButtonsController.SetActive(false);
            _nickname.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        _gameManager.Connected -= PlayerOnConnected;
    }

}
