using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float aggroDistance;
    public float minDistance;
    private float waitTime;
    public float startWaitTime;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public Transform player;

    public Transform[] moveSpots;
    private int randomSpot;

    public bool IsInZone = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if (IsInZone)
        {
            if (Vector2.Distance(transform.position, player.position) < aggroDistance && Vector2.Distance(transform.position, player.position) < minDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                if (timeBtwShots <= 0)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
            else if (Vector2.Distance(transform.position, player.position) < aggroDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                if (timeBtwShots <= 0)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
            else
            {
                patrol();
            }
        }
        else
        {
            patrol();
        }


    }

    private void patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}