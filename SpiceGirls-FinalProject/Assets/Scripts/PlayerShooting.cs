using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float shootCooldown = 0.5f;

    private bool canShoot = false;
    private float lastShootTime = 0f;

    void Update()
    {
        if (!canShoot) return;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
        }
    }

    public void EnableShooting()
    {
        canShoot = true;
        Debug.Log("Shooting enabled!");
    }

    void Shoot()
    {
        if (projectilePrefab == null) return;

        lastShootTime = Time.time;

        GameObject proj = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Rigidbody rb = proj.GetComponent<Rigidbody>();

        if (rb != null)
            rb.linearVelocity = transform.forward * projectileSpeed;

        Destroy(proj, 3f);
        Debug.Log("Shot fired!");
    }
}