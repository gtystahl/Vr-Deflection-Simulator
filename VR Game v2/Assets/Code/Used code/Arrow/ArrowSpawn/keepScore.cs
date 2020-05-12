using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class keepScore : MonoBehaviour
{
    public int totalScore;
    //public GameObject tran;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = 0;
    }

    void Update()
    {
        if (!gameObject.GetComponent<CreateArrow>().enabled)
        {
            //totalScore = 0;
            //switch scene code;

            gameObject.GetComponent<transferScore>().enabled = true;
            gameObject.GetComponent<transferScore>().score = totalScore;
            //SceneManager.LoadScene("end");
        }
    }
    // Update is called once per frame
}
