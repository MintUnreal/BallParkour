using UnityEngine;
using UnityEngine.EventSystems;

public class TouchZone: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool Pressed { get; private set; }
    public Vector2 TouchDelta { get { return TouchDist; }}

    private Vector2 PointerOld;
    private Vector2 TouchDist;
    private int PointerId;

    [SerializeField]
    private float accuracy = 0.1f;

    private void FixedUpdate()
    {
        IsTouching();
    }

    private void IsTouching()
    {
        if (Pressed)
        {
            if (PointerId >= 0 && PointerId < Input.touches.Length)
            {
                TouchDist =  Vector2.Lerp(TouchDist, Input.touches[PointerId].position - PointerOld, accuracy);
                PointerOld = Input.touches[PointerId].position;
            }
            else
            {
                TouchDist = Vector2.Lerp(TouchDist, new Vector2(Input.mousePosition.x, Input.mousePosition.y) - PointerOld, accuracy);
                PointerOld = Input.mousePosition;
            }
        }
        else
        {
            TouchDist = Vector2.Lerp(TouchDist, new Vector2(), accuracy);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Pressed = true;
        PointerId = eventData.pointerId;
        PointerOld = eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Pressed = false;
    }
}