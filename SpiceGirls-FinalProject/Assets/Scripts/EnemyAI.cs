using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float catchDistance = 0.8f;

    private Rigidbody rb;
    private Transform player;
    private bool hasCaught = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (player == null || hasCaught) return;

        Vector3 chaseDirection = (player.position - transform.position).normalized;
        rb.MovePosition(rb.position + chaseDirection * moveSpeed * Time.fixedDeltaTime);

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance < catchDistance)
        {
            hasCaught = true;

            if (GameAudioManager.Instance != null)
                GameAudioManager.Instance.PlayEnemyCatch();

            GameManager.Instance.GameOver();
        }
    }
}