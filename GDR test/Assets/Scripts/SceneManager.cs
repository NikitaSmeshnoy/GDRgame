using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    private Animator winAnimation;
    public GameObject winPanel;
    private Animator loseAnimation;
    public GameObject losePanel;
    public GameObject coinsText;
    private void Start()
    {
        PlayerController.coinsCost = 0;
        PlayerController.isPlayerAlive = true;
        PlayerController.speed = 6;
    }
    private void Update()
    {
        coinsText.gameObject.GetComponent<Text>().text = PlayerController.coinsCost.ToString();
        if (PlayerController.coinsCost > 11)
        {
            Win();
        }
        if (PlayerController.isPlayerAlive == false)
        {
            Lose();
        }
    }
    void Lose()
    {
        losePanel.SetActive(true);
        loseAnimation = losePanel.GetComponent<Animator>();
        loseAnimation.SetBool("isLose", true);
        PlayerController.speed = 0;
    }
    void Win()
    {
        winPanel.SetActive(true);
        winAnimation = winPanel.GetComponent<Animator>();
        winAnimation.SetBool("isWin", true);
        PlayerController.speed = 0;
    }
    public void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
