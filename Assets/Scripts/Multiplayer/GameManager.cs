using UnityEngine;
using Photon.Pun;
using System;

public class GameManager : MonoBehaviourPunCallbacks
{
    public event Action Connected;

    [SerializeField] private GameObject _playerPrefab;
    
    void Start()
    {
        Vector3 _startPosition= new Vector3(UnityEngine.Random.Range(10, 18), 0.01f, UnityEngine.Random.Range(10, 19));
        PhotonNetwork.Instantiate(_playerPrefab.name, _startPosition, Quaternion.identity);
    }

    public void PlayerConnected()
    {
        Connected?.Invoke();
    }
}
