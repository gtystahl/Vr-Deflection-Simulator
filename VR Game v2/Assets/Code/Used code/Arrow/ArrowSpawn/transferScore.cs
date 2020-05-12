using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transferScore : MonoBehaviour
{
    static public int transScore = 0;
    public int score;

    private void Start()
    {
        if (gameObject.name == "arrowSpawner")
        {
            transScore = score;
            SceneManager.LoadScene("end");
        }
        score = transScore;
    }
}
