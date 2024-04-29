using UnityEngine;

public abstract class Pickupable : Interactable
{
    private const string PICK_UP_MESSAGE = "(interact to pick up)";

    [SerializeField] protected GameObject EffectOnDestroyPrefab;

    public override string PromptMessage { get => $"{base.PromptMessage} {PICK_UP_MESSAGE}"; }

    public override void Interact()
    {
        Debug.Log("Picked up");

        if (EffectOnDestroyPrefab)
        {
            Debug.Log("Instantiate prefab");
            Instantiate(EffectOnDestroyPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);

        base.Interact();
    }
}
