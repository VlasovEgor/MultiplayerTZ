using UnityEngine;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    [SerializeField] private Text _chatText;
    [SerializeField] private MoveCharacterWithButtons _moveCharacterWithButtons;
    private TouchScreenKeyboard _screenKeyboard;

    public void OpenKeyboard()
    {   
        _screenKeyboard = TouchScreenKeyboard.Open("",TouchScreenKeyboardType.Default);
        _moveCharacterWithButtons.enabled = false;
    }
    private void Update()
    {
        if(TouchScreenKeyboard.visible==false && _screenKeyboard!=null)
        {
            if(_screenKeyboard.done)
            {
                _chatText.text = _screenKeyboard.text;
                _screenKeyboard = null;
            }
        }
    }
}
