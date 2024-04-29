using UnityEngine;

public abstract class Shootable : MonoBehaviour
{
    public void KillShootable() => Destroy(gameObject);

    protected abstract void AbstractKillShootable();
}
