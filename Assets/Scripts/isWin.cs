using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class isWin : MonoBehaviour
{
    public GameObject fadeScreen;
    public GameObject winText;
    public GameObject player;
    public int countEnemy;

 
    private void Update()
    {
        if(countEnemy == 0)
        {
            FadingOut();
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            countEnemy -= 1;
        }
        if (countEnemy == -1)
        {
            StartCoroutine(ChangerDeSceneAvecDelai());
        }

    }

    IEnumerator ChangerDeSceneAvecDelai()
    {
        // Attend 2 secondes
        yield return new WaitForSeconds(5f);

        if (Input.GetMouseButtonDown(0))
        {
            // Charge la scène d'index 0
            SceneManager.LoadScene(0);
        }
    }
    public void FadingOut()
    {
        fadeScreen.GetComponent<Animation>().Play("FadeoutAnim");
        winText.GetComponent<Animation>().Play("winTextAnim");

    }
}
