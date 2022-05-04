using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ChangingClothes : MonoBehaviour, IPunObservable
{
    [SerializeField] private List<�lothes> _�lothesList = new List<�lothes>();

    public void GetClothesList(ref List<�lothes> �lothesList)
    {
        �lothesList = _�lothesList;
    }

    public void ChangeClothes(�lothes �lothes)
    {
        if (�lothes.GetClothesStatus() == true)
        {
            �lothes.SetClothesStatus(false);
            �lothes.GetClothes().gameObject.SetActive(false);
            �lothes.GetNackedClothes().gameObject.SetActive(true);
        }
        else
        {
            �lothes.SetClothesStatus(true);
            �lothes.GetClothes().gameObject.SetActive(true);
            �lothes.GetNackedClothes().gameObject.SetActive(false);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            for (int i = 0; i < _�lothesList.Count; i++)
            {
                stream.SendNext(_�lothesList[i].GetClothesStatus());
            }
        }
        else
        {
            for (int i = 0; i < _�lothesList.Count; i++)
            {
                _�lothesList[i].SetClothesStatus(!(bool)stream.ReceiveNext());
                ChangeClothes(_�lothesList[i]);
            }
        }
    }
}