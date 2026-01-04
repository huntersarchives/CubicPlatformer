using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 movement;
    public static bool jump;
    public static bool interact;

    private PlayerInput playerInput;
    private InputAction inputAction;
    private InputAction jumpAction;
    private InputAction interactAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();

        inputAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        interactAction = playerInput.actions["Interact"];
    }

    // Update is called once per frame
    void Update()
    {
        movement = inputAction.ReadValue<Vector2>();
        jump = jumpAction.WasPressedThisFrame();
        interact = interactAction.WasPressedThisDynamicUpdate();
    }
}
