using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    private PlayerInputs playerInputs;

    private void Awake() 
    {
        if(Instance != null)
        {
            Debug.LogError($"More than one instance for {this}");
            Destroy(this.gameObject);
            return;
        }

        Instance = this;

        playerInputs = new PlayerInputs();
    }

    private void OnEnable() 
    {
        playerInputs.Enable();
    }

    public Vector2 GetMovementInput()
    {
        return playerInputs.Player.Movement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseLookInput()
    {
        return playerInputs.Player.Look.ReadValue<Vector2>();
    }

    public bool GetJumpInput()
    {
        return playerInputs.Player.Jump.triggered;
    }

    private void OnDisable() 
    {
        playerInputs.Disable();
    }
}
