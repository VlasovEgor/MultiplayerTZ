using UnityEngine;
using Photon.Pun;


public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject _playerPrefab;

    void Start()
    {
        
        Vector3 _startPosition= new Vector3(Random.Range(10, 18), 0.01f, Random.Range(10, 19));
        PhotonNetwork.Instantiate(_playerPrefab.name, _startPosition, Quaternion.identity);
    }
}
