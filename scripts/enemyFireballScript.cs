using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFireballScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float force;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 6 || transform.position.x <= -6)
        {
            Destroy(gameObject);
        }
        if (transform.position.y >= 6 || transform.position.y <= -6)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.Play("Fireball_impact_animation");
            player.GetComponent<PlayerCombat>().takeDamage(20);
            Destroy(gameObject, 0.3f);
        } else if (collision.gameObject.CompareTag("Terrain"))
        {
            animator.Play("Fireball_impact_animation");
            Destroy(gameObject, 0.3f);
        }
    }
}
