using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpHeight = 0.5f;

    private CharacterController characterController;
    private Vector3 playerVelocity;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = new(input.x, 0, input.y);

        characterController.Move(playerSpeed * Time.deltaTime * transform.TransformDirection(moveDirection));

        playerVelocity.y += gravity * Time.deltaTime;

        if (characterController.isGrounded && playerVelocity.y < 0)
            playerVelocity.y = gravity;

        characterController.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (characterController.isGrounded)
            playerVelocity.y = jumpHeight * -gravity;
    }
}
