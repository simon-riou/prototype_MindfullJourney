using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorScript : MonoBehaviour
{
    public GameObject ennemi;
    public string playerTag = "Player";
    public GameObject gameManager;
    public GameObject explosion;
    private void Start()
    {
        Debug.Log("script working");
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("trigger");
        if (other.collider.CompareTag(playerTag))
        {
            Debug.Log("Le personnage principal a touché le docteur.");

            // Faire disparaître le docteur et l'ennemi
            gameObject.SetActive(false);
            gameManager.GetComponent<isWin>().countEnemy -= 1;
            Destroy(ennemi);
            Instantiate(explosion, ennemi.transform.position, Quaternion.identity);
            //ennemi.SetActive(false);
        }
    }
}

