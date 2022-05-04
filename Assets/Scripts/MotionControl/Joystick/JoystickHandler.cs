using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public abstract class JoystickHandler : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    [Header("Joystick images")]
    [SerializeField] private Image _joystickBackground;
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _joystickArea;

    private Vector2 _joystickBackgroundStartPosition;

    protected Vector2 _inputVector;

    [Header("Joystick color")]
    [SerializeField] private Color _inActiveJoystickColor;
    [SerializeField] private Color _activeJoystickColor;

    private bool _joystickIsActive = false;

    private void Start()
    {
        TapEffect();

        _joystickBackgroundStartPosition = _joystickBackground.rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform, eventData.position, null, out joystickPosition))
        {
            ChangingJoystickPosition(joystickPosition);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 joystickBackgroundPosition;

        TapEffect();
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickArea.rectTransform, eventData.position, null, out joystickBackgroundPosition))
        {
            _joystickBackground.rectTransform.anchoredPosition = new Vector2(joystickBackgroundPosition.x, joystickBackgroundPosition.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystickBackground.rectTransform.anchoredPosition = _joystickBackgroundStartPosition;

        TapEffect();

        _inputVector = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    private void TapEffect()
    {
        if (_joystickIsActive == false)
        {
            _joystick.color = _activeJoystickColor;
            _joystickIsActive = true;
        }
        else
        {
            _joystick.color = _inActiveJoystickColor;
            _joystickIsActive = false;
        }
    }

    private void ChangingJoystickPosition(Vector2 joystickPosition)
    {
        joystickPosition.x = (joystickPosition.x * 2 / _joystickBackground.rectTransform.sizeDelta.x);
        joystickPosition.y = (joystickPosition.y * 2 / _joystickBackground.rectTransform.sizeDelta.y);

        _inputVector = new Vector2(joystickPosition.x, joystickPosition.y);
        _inputVector = (_inputVector.magnitude > 1f) ? _inputVector.normalized : _inputVector;
        _joystick.rectTransform.anchoredPosition = new Vector2(_inputVector.x * (_joystickBackground.rectTransform.sizeDelta.x / 2), _inputVector.y * (_joystickBackground.rectTransform.sizeDelta.y / 2));
    }
}
