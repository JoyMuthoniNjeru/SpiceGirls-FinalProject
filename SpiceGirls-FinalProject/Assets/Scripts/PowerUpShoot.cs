using UnityEngine;

public class PowerUpShoot : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShooting shooting = other.GetComponent<PlayerShooting>();
            if (shooting != null)
                shooting.EnableShooting();

            if (GameAudioManager.Instance != null)
                GameAudioManager.Instance.PlayShootPickup();

            Destroy(gameObject);
        }
    }
}