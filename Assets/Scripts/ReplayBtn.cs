using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayBtn : MonoBehaviour
{
    public void SceneLoad(string Gameover)
    {
        SceneManager.LoadScene(Gameover);
    }
}
