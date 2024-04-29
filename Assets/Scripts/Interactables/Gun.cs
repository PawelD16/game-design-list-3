public class Gun : Pickupable
{
    protected override string AbstractPromptMessage { get => "Pick up the gun"; }

    protected override void AbstractInteract() => PlayerManager.HasGun = true;
}
