using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Key : MonoBehaviour
{
    public GameObject clearPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Time.timeScale = 0.0f;
            clearPanel.gameObject.SetActive(true);
        }
    }

    public void yes(string Stage1)
    {
        SceneManager.LoadScene(Stage1);
        Time.timeScale = 1.0f;
    }
    
    public void yes1(string Stage2)
    {
        SceneManager.LoadScene(Stage2);
        Time.timeScale = 1.0f;
    }
    
    public void yes2(string Stage3)
    {
        SceneManager.LoadScene(Stage3);
        Time.timeScale = 1.0f;
    }
}
