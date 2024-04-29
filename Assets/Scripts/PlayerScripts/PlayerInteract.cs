using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask layerMask;

    private Camera interactCamera;
    private PlayerUI playerUI;
    private InputManager inputManager;

    private void Start()
    {
        interactCamera = GetComponent<PlayerLookAround>().PlayerCamera;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    private void Update() => InteractUsingRaycast();

    private void InteractUsingRaycast()
    {
        Ray ray = new(interactCamera.transform.position, interactCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactDistance, layerMask) && hitInfo.collider.TryGetComponent<Interactable>(out var interactable))
        {
            playerUI.UpdatePromptText(interactable.PromptMessage);

            if (inputManager.OnFoot.Interact.triggered)
                interactable.Interact();
        }
        else
        {
            playerUI.UpdatePromptText(string.Empty);
        }
    }
}
