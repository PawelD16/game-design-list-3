using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private AudioClip soundEffect;

    private Camera shootCamera;
    private AudioSource audioSource;

    private void Start()
    {
        shootCamera = GetComponent<PlayerLookAround>().PlayerCamera;
        audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        Debug.Log("Shoot!");

        PlayShootSound();

        Ray ray = new(shootCamera.transform.position, shootCamera.transform.forward);

        bool hasHit = Physics.Raycast(ray, out RaycastHit hitInfo, layerMask);
        Shootable hitObject = hitInfo.collider?.GetComponent<Shootable>();

        if (hasHit && hitObject != null)
        {
            Debug.Log("Hit!");

            hitObject.KillShootable();
            PlayerManager.IncrementEnemiesKilled();
        }
    }

    public void PlayShootSound() => audioSource.PlayOneShot(soundEffect);
}
