using UnityEngine;

public class Dot : MonoBehaviour
{
    public int pointValue = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.AddPoints(pointValue);

            if (GameAudioManager.Instance != null)
                GameAudioManager.Instance.PlayDotCollect();

            Destroy(gameObject);
        }
    }
}