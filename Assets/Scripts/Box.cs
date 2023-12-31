using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public GameObject bPanel;
    public GameObject boxPanel;

    private Player playerMovement;
    private bool hasCollided = false;

    void Start()
    {
        playerMovement = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasCollided)
        {
            Time.timeScale = 0.0f;
            bPanel.gameObject.SetActive(true);
            hasCollided = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bPanel.gameObject.SetActive(false);
        }
    }

    public void yes()
    {
        bPanel.SetActive(false);
        boxPanel.SetActive(true);
    }

    public void no()
    {
        bPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void IncreasePlayerSpeed()
    {
        boxPanel.SetActive(false);
        playerMovement.IncreaseSpeed();
        Time.timeScale = 1.0f;
    }
    
    public void HealHp()
    {
        boxPanel.SetActive(false);
        playerMovement.HealHp();
        Time.timeScale = 1.0f;
    }
}
