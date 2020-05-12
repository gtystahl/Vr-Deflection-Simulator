using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOfArrow : MonoBehaviour
{
    public GameObject aud;
    public int arrowsNeeded;
    public float moveSpeed;
    //public float rotateSpeed;
    //public float time;
    //public float timeToComplete;
    private int arrowsMade;
    public float time;
    private float changeSpeed;
    private float changeTime;
    private float changeBy;
    public bool switchSpeed;
    private bool once;

    // Start is called before the first frame update
    void Start()
    {
        //timeToComplete = 10;
        //time = 0;
        once = true;
        moveSpeed = 2f;
        arrowsNeeded = 10;
        time = 0;
        changeSpeed = .5f;
        changeTime = 54;
        changeBy = 15;
        switchSpeed = false;
        //rotateSpeed = .5f;
        //timeToComplete = (4 * moveSpeed) + (6 * rotateSpeed) + .5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.GetComponent<CreateArrow>().superFirst)
            time += Time.deltaTime;

        if (!gameObject.GetComponent<CreateArrow>().superFirst && time >= changeTime)
        {
            if (moveSpeed > 1.001)
            {
                gameObject.GetComponent<CreateArrow>().first = true;
                moveSpeed -= changeSpeed;
                changeSpeed /= 2;
                //changeTime -= changeBy;
                //changeBy /= 2;
                if (changeTime == 54)
                {
                    changeTime = 16;
                } else if (moveSpeed < 1.2)
                {
                    changeTime = 8.20f;
                }
            } else if (moveSpeed > .55)
            {
                if (once)
                {
                    gameObject.GetComponent<CreateArrow>().superFirst = true;
                    gameObject.GetComponent<CreateArrow>().wait = 39.5f;
                    aud.GetComponent<audioStuff>().enabled = true;
                    once = false;
                }
                gameObject.GetComponent<CreateArrow>().first = true;
                moveSpeed -= .1f;
                changeTime = 30;
            }
            //gameObject.GetComponent<CreateArrow>().arrowsCreated = 0;
            //arrowsNeeded++;
            time = 0;
        }
        

    }
}
