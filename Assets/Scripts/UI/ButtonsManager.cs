using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private ChangingClothes _changingClothes;

    private List<�lothes> _�lothesList = new List<�lothes>();

    private void Start()
    {
        _changingClothes.GetClothesList(ref _�lothesList);
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
        Application.Quit();
    }

    public void TakeOffOnBody()
    {
        for (int i = 0; i < _�lothesList.Count; i++)
        {
            if (_�lothesList[i].GetClothingName() == "Body")//�������� ������������� ����������
            {
                _changingClothes.ChangeClothes(_�lothesList[i]);
            }
        }
    }

    public void TakeOffOnPants()
    {
        for (int i = 0; i < _�lothesList.Count; i++)
        {
            if (_�lothesList[i].GetClothingName() == "Pants")
            {
                _changingClothes.ChangeClothes(_�lothesList[i]);
            }
        }
    }
    public void TakeOffOnBoots()
    {
        for (int i = 0; i < _�lothesList.Count; i++)
        {
            if (_�lothesList[i].GetClothingName() == "Boots")
            {
                _changingClothes.ChangeClothes(_�lothesList[i]);
            }
        }
    }
}
