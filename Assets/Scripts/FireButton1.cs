using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool buttonPressed;

    void Start()
    {
        buttonPressed = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
    }

    public bool IsButtonPressed()
    {
        return buttonPressed;
    }
}
