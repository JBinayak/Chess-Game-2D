using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject fireBall;
    public Transform fireballPosition;
    public Animator animator;

    private float timer;
    private GameObject player;
    gameAudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<gameAudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.activeInHierarchy)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < 7)
            {
                timer += Time.deltaTime;

                if (timer >= 2)
                {
                    timer = 0;
                    shoot();
                }

            }
        }
    }

    void shoot()
    {
        audioManager.PlaySFX(audioManager.fireball);
        animator.SetTrigger("attacks");
        Invoke("spawnFireball", 0.4f);

    }

    void spawnFireball()
    {
        Instantiate(fireBall, fireballPosition.position, Quaternion.identity);

    }
}
