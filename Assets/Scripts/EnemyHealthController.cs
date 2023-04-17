using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int enemyHealth;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject explosion;

    public GameObject gameManager;

    private void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    private void Update()
    {
        timeBtwShots -= Time.deltaTime;

        if(enemyHealth <= 0)
        {
            gameManager.GetComponent<isWin>().countEnemy -= 1;
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
    }

    void OnMouseDown()
    {
        
        if (timeBtwShots <= 0)
        {
            Debug.Log("click sur " + this.gameObject.name);
            enemyHealth -= 1;
            timeBtwShots = startTimeBtwShots;
        }
    }
}
