using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputHandler : MonoBehaviour
{

    [SerializeField]
    private Camera sceneCamera;

    private Vector2 mouseScreenPosition;

    [Header("Torretas")]
    [SerializeField] private InputActionReference turretAAction;
    [SerializeField] private InputActionReference turretBAction;
    [SerializeField] private InputActionReference turretCAction;

    public event Action<int> OnTurretSelected;

    [SerializeField]
    private LayerMask placementMask;


    private void OnEnable()
    {
        turretAAction.action.performed += ctx => OnTurretSelected ?.Invoke(0);
        turretBAction.action.performed += ctx => OnTurretSelected?.Invoke(1);
        turretCAction.action.performed += ctx => OnTurretSelected?.Invoke(2);

        turretAAction.action.Enable();
        turretBAction.action.Enable();
        turretCAction.action.Enable();

    }

    private void OnDisable()
    {
        turretAAction.action.performed -= ctx => OnTurretSelected?.Invoke(0);
        turretBAction.action.performed -= ctx => OnTurretSelected?.Invoke(1);
        turretCAction.action.performed -= ctx => OnTurretSelected?.Invoke(2);

        turretAAction.action.Disable();
        turretBAction.action.Disable();
        turretCAction.action.Disable();
    }
    public Vector2 GetSelectedMapPosition()
    {
        mouseScreenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = sceneCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x,
            mouseScreenPosition.y, sceneCamera.nearClipPlane));
        return mouseWorldPos;
    }
}
