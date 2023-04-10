using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth;

    public GameObject fadeScreen;
    public GameObject loseText;


    [SerializeField] private Image[] hearths;



    private void Update()
    {
        UpdateHealth();

        if(playerHealth == 0)
        {
            FadingOut();
            GetComponent<PlayerController>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            playerHealth = -1;
        }
    }

    public void FadingOut()
    {
        fadeScreen.GetComponent<Animation>().Play("FadeoutAnim");
        loseText.GetComponent<Animation>().Play("TextFadeoutAnim");

    }

    public void UpdateHealth()
    {
        for(int i = 0; i < hearths.Length; i++) { 
            if(i < playerHealth)
            {
                hearths[i].color = Color.white;
            }
            else
            {
                hearths[i].color = Color.gray;
            }
        }
    }
}
