using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterData playerData;
    private Rigidbody2D playerRB;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    public BoolData canRun;
    private WaitForFixedUpdate wffuObj;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Move.performed += startMove;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        playerRB.MovePosition(playerRB.position + inputVector * (playerData.speed * Time.deltaTime));
    }

    public void startMove(InputAction.CallbackContext context)
    {
        Debug.Log(context);
    }

    private IEnumerator Move()
    {
        while (canRun.value)
        {
            Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
            playerRB.MovePosition(playerRB.position + inputVector * (playerData.speed * Time.deltaTime));
            yield return wffuObj;
        }
    }
}

