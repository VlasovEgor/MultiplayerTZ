using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _nicknameInput;

    void Start()
    {
        PhotonNetwork.NickName = "PLayer" + Random.Range(1, 9);
        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void CreateRoom()
    {
        PhotonNetwork.NickName = _nicknameInput.text;
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.NickName = _nicknameInput.text;
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {

        PhotonNetwork.LoadLevel("GameScene");
    }
}
