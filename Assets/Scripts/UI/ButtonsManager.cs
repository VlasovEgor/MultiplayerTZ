using UnityEngine;
using Photon.Pun;
using System.Collections.Generic;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private ChangingClothes _changingClothes;

    private List<Ñlothes> _ñlothesList = new List<Ñlothes>();

    private void Start()
    {
        _changingClothes.GetClothesList(ref _ñlothesList);
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
        Application.Quit();
    }

    public void TakeOffOnBody()
    {
        for (int i = 0; i < _ñlothesList.Count; i++)
        {
            if (_ñlothesList[i].GetClothingName() == "Body")//äîâîëüíî êîñòûëüíåíüêî ïîëó÷èëîñü
            {
                _changingClothes.ChangeClothes(_ñlothesList[i]);
            }
        }
    }

    public void TakeOffOnPants()
    {
        for (int i = 0; i < _ñlothesList.Count; i++)
        {
            if (_ñlothesList[i].GetClothingName() == "Pants")
            {
                _changingClothes.ChangeClothes(_ñlothesList[i]);
            }
        }
    }

    public void TakeOffOnBoots()
    {
        for (int i = 0; i < _ñlothesList.Count; i++)
        {
            if (_ñlothesList[i].GetClothingName() == "Boots")
            {
                _changingClothes.ChangeClothes(_ñlothesList[i]);
            }
        }
    }
}
