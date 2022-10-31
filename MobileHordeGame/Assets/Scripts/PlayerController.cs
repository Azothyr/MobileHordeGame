using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterData playerData;
    public Rigidbody2D playerRB;


    private InputActions inputActions;
    private Vector2 inputMoveVector;
    private Vector2 inputAimVector;
    private Vector2 currentLocation;

    private WaitForFixedUpdate wffuObj = new WaitForFixedUpdate();

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody2D>();
        
        
        inputActions = new InputActions();
        
        inputActions.Player.Enable();
        
        inputActions.Player.Move.performed += StartMove;
        inputActions.Player.Move.canceled += StopMove;
        
        inputActions.Player.Aim.performed += StartFiring;
        inputActions.Player.Aim.canceled += StopFiring;
    }

    private void StartFiring(InputAction.CallbackContext context)
    {
        inputAimVector = context.ReadValue<Vector2>();
        playerData.aimDirection.SetValue(inputAimVector.x,inputAimVector.y);
        playerData.isFiring.value = true;
    }

    private void StopFiring(InputAction.CallbackContext context)
    {
        playerData.aimDirection.SetValue(0,0);
        playerData.isFiring.value = false;
    } 
    
    private void StartMove(InputAction.CallbackContext context)
    {
        inputMoveVector = context.ReadValue<Vector2>();
        StartCoroutine(Move());
    }

    private void StopMove(InputAction.CallbackContext context)
    {
        inputMoveVector = context.ReadValue<Vector2>();
        StopCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (playerData.canRun.value)
        {
            currentLocation = playerRB.position;
            playerData.v3Position.SetValue(currentLocation.x, currentLocation.y, 0);
            playerRB.MovePosition(currentLocation + inputMoveVector * (playerData.speed * Time.deltaTime));
            yield return wffuObj;
        }
    }

    public void ResetV3()
    {
        currentLocation = playerRB.position;
        playerData.v3Position.SetValue(currentLocation.x, currentLocation.y, 0);
    }
}

