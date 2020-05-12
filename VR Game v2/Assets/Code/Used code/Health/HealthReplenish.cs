using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthReplenish : MonoBehaviour
{
    public float time;
    public GameObject spawner;
    public bool good;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        good = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((good || spawner.GetComponent<CreateArrow>().superFirst) && (spawner.GetComponent<keepScore>().totalScore != 0)) {
            time += Time.deltaTime;
            good = true;
            if (time >= 2 && gameObject.GetComponent<playerHealth>().health < 5)
            {
                gameObject.GetComponent<playerHealth>().health++;
                time = 0;
            } else if (gameObject.GetComponent<playerHealth>().health >= 5)
            {
                good = false;
            }
        }
    }
}
