using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private RectTransform joysticRect;
    private Vector2 touchPosition;

    void Start()
    {
        touchPosition = Vector2.zero;
        joysticRect = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if
        (
            RectTransformUtility.ScreenPointToLocalPointInRectangle
            (joysticRect, eventData.position, eventData.enterEventCamera, out touchPosition)               
        )
        {
            touchPosition.x /= joysticRect.sizeDelta.x;
            touchPosition.y /= joysticRect.sizeDelta.y;

            touchPosition.x = (touchPosition.x < 0.5) ? touchPosition.x * 2 - 1 : (touchPosition.x - 0.5f) * 2;
            touchPosition.y = (touchPosition.y < 0.5) ? touchPosition.y * 2 - 1 : (touchPosition.y - 0.5f) * 2;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        touchPosition = Vector2.zero;
    }

    public Vector2 GetPosition()
    {
        return touchPosition;
    }

    
}
