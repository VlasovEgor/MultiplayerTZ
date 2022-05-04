using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangingClothes : MonoBehaviour, IPunObservable
{
    [SerializeField] private List<Ñlothes> _ñlothesList = new List<Ñlothes>();

    public void GetClothesList(ref List<Ñlothes> ñlothesList)
    {
        ñlothesList = _ñlothesList;
    }

    public void ChangeClothes(Ñlothes Ñlothes)
    {
        if (Ñlothes.GetClothesStatus() == true)
        {
            Ñlothes.SetClothesStatus(false);
            Ñlothes.GetClothes().gameObject.SetActive(false);
            Ñlothes.GetNackedClothes().gameObject.SetActive(true);
        }
        else
        {
            Ñlothes.SetClothesStatus(true);
            Ñlothes.GetClothes().gameObject.SetActive(true);
            Ñlothes.GetNackedClothes().gameObject.SetActive(false);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            for (int i = 0; i < _ñlothesList.Count; i++)
            {
                stream.SendNext(_ñlothesList[i].GetClothesStatus());
            }
        }
        else
        {
            for (int i = 0; i < _ñlothesList.Count; i++)
            {
                _ñlothesList[i].SetClothesStatus(!(bool)stream.ReceiveNext());
                ChangeClothes(_ñlothesList[i]);
            }
        }
    }
}