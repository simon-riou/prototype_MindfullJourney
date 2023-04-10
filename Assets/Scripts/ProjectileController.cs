using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ProjectileController : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    public GameObject explosion;

    public HealthController hc;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hc = player.GetComponent<HealthController>();

        target = new Vector2(player.position.x, player.position.y);

        Vector3 direction = (player.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            hc.playerHealth -= 1;
        }
        DestroyProjectile();
    }

    void DestroyProjectile()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
