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
    }
}
