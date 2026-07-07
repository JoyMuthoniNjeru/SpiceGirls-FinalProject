using UnityEngine;
using System.Collections;

public class PowerUpSpeed : MonoBehaviour
{
    public float speedBoostAmount = 3f;
    public float boostDuration = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
                StartCoroutine(ApplySpeedBoost(player));

            if (GameAudioManager.Instance != null)
                GameAudioManager.Instance.PlaySpeedBoost();

            Destroy(gameObject);
        }
    }

    IEnumerator ApplySpeedBoost(PlayerController player)
    {
        float originalSpeed = player.moveSpeed;
        player.moveSpeed += speedBoostAmount;
        yield return new WaitForSeconds(boostDuration);
        player.moveSpeed = originalSpeed;
    }
}