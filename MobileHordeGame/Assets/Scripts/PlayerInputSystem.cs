using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerInputSystem : MonoBehaviour
{
    public CharacterData data;
    private Rigidbody playerRigidbody;
    private Vector3 inputDirection;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void Move(InputValue value)
    {
        Vector2 inputMovement = value.Get<Vector2>();
        inputDirection = new Vector3(inputMovement.x, inputMovement.y, 0);
    }
}
