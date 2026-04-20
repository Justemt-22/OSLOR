using UnityEngine;
using UnityEngine.InputSystem;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject mouseIndicator, cellIndicator;
    [SerializeField]
    private GameObject [] turretPrefabs;
    private int turretIndex = 0;
    [SerializeField]
    private InputHandler inputHandler;
    [SerializeField]
    private InputAction clickAction;
    [SerializeField]
    public InputActionAsset inputActions;
    [SerializeField]
    private Grid grid;

    private void Awake()
    {
        clickAction = inputActions.FindActionMap("Player").FindAction("Click");
        clickAction.performed += OnClickPerformed;
    }

    private void OnEnable()
    {
        inputHandler.OnTurretSelected += ChangeSelectedTurret;
        clickAction.Enable();

    }

    private void OnDisable()
    {
        inputHandler.OnTurretSelected -= ChangeSelectedTurret;
        clickAction.Disable();
    }


    private void ChangeSelectedTurret(int index)
    {
        turretIndex = index;
        Debug.Log("Toirreta cambiada");
    }
    private void Update()
    {
        Vector2 mousePosition = inputHandler.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(new Vector3(mousePosition.x,
            mousePosition.y, 0));
        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.GetCellCenterWorld(gridPosition);
    }

    private void OnClickPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Di click");
        Instantiate(turretPrefabs[turretIndex], cellIndicator.transform.position, Quaternion.identity);
    }
}
