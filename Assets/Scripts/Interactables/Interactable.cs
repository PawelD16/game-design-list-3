using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public virtual string PromptMessage { get => AbstractPromptMessage; }
    protected abstract string AbstractPromptMessage { get; }

    public virtual void Interact() => AbstractInteract();
    protected abstract void AbstractInteract();
}
