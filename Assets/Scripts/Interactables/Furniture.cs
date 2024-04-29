using UnityEngine;

public class Furniture : Interactable
{
    protected override string AbstractPromptMessage => "This is a piece of furniture";

    protected override void AbstractInteract() => Debug.Log("I AM FURNITURE!");
}
