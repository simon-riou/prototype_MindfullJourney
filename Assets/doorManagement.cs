using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorManagement : MonoBehaviour
{
    public string playerTag = "Player";

    public GameObject doorText;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("trigger porte");
        if (other.collider.CompareTag(playerTag))
        {
            Debug.Log("Le personnage principal a touch� la porte.");
            doorText.GetComponent<Animation>().Play("doorTextAnim");
            gameObject.SetActive(false);
            
            //ennemi.SetActive(false);
        }
    }
}
