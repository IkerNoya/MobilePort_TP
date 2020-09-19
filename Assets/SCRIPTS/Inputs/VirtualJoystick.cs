using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] RectTransform stick;
    [SerializeField] Image background;
    public float joystickLimit;
    Vector2 ConvertToLocalPos(PointerEventData eventData)
    {
        Vector2 newPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, eventData.position, eventData.enterEventCamera, out newPos);
        return newPos;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 stickPos = ConvertToLocalPos(eventData);    
        if(stickPos.magnitude > joystickLimit)
        {
            stickPos = stickPos.normalized * joystickLimit;
        }
        stick.anchoredPosition = stickPos;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        background.color = Color.blue;
        stick.anchoredPosition = ConvertToLocalPos(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        background.color = Color.gray;
        stick.anchoredPosition = Vector2.zero;
    }
}
