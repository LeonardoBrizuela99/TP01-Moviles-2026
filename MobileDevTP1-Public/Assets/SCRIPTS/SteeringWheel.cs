using UnityEngine;
using UnityEngine.EventSystems;

public class SteeringWheel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform visualWheel;

    private const float deadZoneRadius = 0.05f;

    private RectTransform hitArea;
    private bool isHeld;
    private Vector2 activeScreenPosition;
    private Camera activeCamera;

    public float TurnDir = 0;

    private void Awake()
    {
        hitArea = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHeld = true;
        activeScreenPosition = eventData.position;
        activeCamera = eventData.pressEventCamera;
    }

    public void OnDrag(PointerEventData eventData)
    {
        activeScreenPosition = eventData.position;
        activeCamera = eventData.pressEventCamera;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHeld = false;
    }

    private void Update()
    {
        if (isHeld)
        {
            Vector2 fromCenter = GetFromWheelCenter(activeScreenPosition, activeCamera);

            if (fromCenter.magnitude < deadZoneRadius * visualWheel.rect.width)
            {
                return;
            }

            float angle = -Mathf.Atan2(fromCenter.x, fromCenter.y) * Mathf.Rad2Deg;
            visualWheel.localRotation = Quaternion.Euler(0f, 0f, angle);
        }


        TurnDir = (visualWheel.localRotation * Vector3.up).x;
    }

    private Vector2 GetFromWheelCenter(Vector2 screenPos, Camera cam)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(hitArea, screenPos, cam, out Vector3 worldPoint);
        Vector3 local = hitArea.InverseTransformVector(worldPoint - visualWheel.position);
        return new Vector2(local.x, local.y);
    }
}