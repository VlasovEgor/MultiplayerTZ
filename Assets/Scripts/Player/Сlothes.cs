using UnityEngine;

public class Сlothes : MonoBehaviour
{
    [SerializeField] private bool _clothesIsOn = true;
    [SerializeField] private GameObject _clothes;
    [SerializeField] private GameObject _nackedClothes;
    [SerializeField] private string _clothingName;

    public bool GetClothesStatus()
    {
        return _clothesIsOn;
    }

    public void SetClothesStatus(bool currentClothesStatus)
    {
        _clothesIsOn = currentClothesStatus;
    }

    public GameObject GetClothes()
    {
        return _clothes;
    }

    public GameObject GetNackedClothes()
    {
        return _nackedClothes;
    }

    public string GetClothingName()
    {
        return _clothingName;
    }
}