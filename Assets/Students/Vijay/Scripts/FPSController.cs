using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravityValue;
    [SerializeField] private Transform cameraTransform;

    private CharacterController characterController;
    private bool isGrounded;
    private Vector3 playerVelocity;

    private void Start() 
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() 
    {
        isGrounded = characterController.isGrounded;

        if(isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 moveInput = InputManager.Instance.GetMovementInput();
        Vector3 move = new Vector3(moveInput.x, 0f, moveInput.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        if(InputManager.Instance.GetJumpInput() && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }
}