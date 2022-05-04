using UnityEngine;

public class ReplacingControls : MonoBehaviour
{
    [SerializeField] private GameObject _controllerCanvas;
    [SerializeField] private MoveCharacterWithButtons _moveCharacterWithButtons;

    private void Awake()
    {
        if(Application.platform==RuntimePlatform.Android)
        {
            _controllerCanvas.SetActive(true);
            _moveCharacterWithButtons.enabled=false;
        }
        else
        {
            _controllerCanvas.SetActive(false);
            _moveCharacterWithButtons.enabled = true;
        }
    }
}
