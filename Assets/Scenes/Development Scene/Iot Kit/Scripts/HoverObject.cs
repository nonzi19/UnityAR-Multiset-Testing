using UnityEngine;
using UnityEngine.EventSystems;

public class HoverObject : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Camera _mainCamera;

    [Header("Label Settings")]
    [SerializeField] private int _labelIndex;

    private void Awake()
    {
        if (_mainCamera == null)
            _mainCamera = Camera.main;
    }

    private void Update()
    {
        _TouchHandler();
    }

    private void _TouchHandler()
    {
        if (_mainCamera == null)
            return;

        // Mobile touch input.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase != TouchPhase.Began)
                return;

            if (EventSystem.current != null &&
                EventSystem.current.IsPointerOverGameObject(
                    touch.fingerId))
                return;

            CheckHit(touch.position);
        }
        // Mouse input in the Unity Editor.
        else if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current != null &&
                EventSystem.current.IsPointerOverGameObject())
                return;

            CheckHit(Input.mousePosition);
        }
    }

    private void CheckHit(Vector2 screenPosition)
    {
        Ray ray = _mainCamera.ScreenPointToRay(screenPosition);

        if (!Physics.Raycast(ray, out RaycastHit hit))
            return;

        HoverObject clickedObject =
            hit.collider.GetComponentInParent<HoverObject>();

        if (clickedObject != this)
            return;

        if (LabelController.Instance != null)
        {
            LabelController.Instance.ToggleLabel(_labelIndex);
        }
        else
        {
            Debug.LogWarning("LabelController is missing from the scene.");
        }
    }
}