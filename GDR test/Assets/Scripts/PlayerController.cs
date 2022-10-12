using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator deathAnimation;
    public LineController lineController;
    public static int coinsCost;
    public static bool isPlayerAlive;
    public static float speed;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            CollectCoin(other);
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            PlayerDeath(other);
        }
    }  
    private void CollectCoin(Collider2D other)
    {
        coinsCost++;
        Destroy(other.gameObject);
    }
    private void PlayerDeath(Collider2D other)
    {
        deathAnimation = GetComponent<Animator>();
        deathAnimation.SetBool("isDeath", true);
        lineController.DeleteLine();
        isPlayerAlive = false;
    }
}
