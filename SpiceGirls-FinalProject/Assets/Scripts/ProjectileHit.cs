using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    public int pointsOnHit = 20;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ScoreManager.Instance.AddPoints(pointsOnHit);
            Debug.Log("Enemy hit! +" + pointsOnHit + " points");

            // Respawn enemy at starting position
            collision.gameObject.transform.position = new Vector3(7, 1, 7);

            Destroy(gameObject);
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}