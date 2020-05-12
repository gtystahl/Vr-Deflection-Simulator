using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateArrow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject score;
    private int iter;

    public float time;
    public float changeTime;
    public int arrowsCreated;
    public bool first = true;
    public float spawnRate;
    public GameObject clone;
    public Vector3 setpos;
    public bool superFirst = true;
    public float wait;

    // Start is called before the first frame update
    void Start()
    {
        iter = 0;
        spawnRate = gameObject.GetComponent<SpeedOfArrow>().moveSpeed / 2f;
        wait = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnRate > .1)
        {
            spawnRate = gameObject.GetComponent<SpeedOfArrow>().moveSpeed / 2f;
        }
        changeTime = Time.deltaTime;
        time += changeTime;
        /*
        if (iter == 60)
        {
            Instantiate(arrow);
            iter = 100;
        }

        if (iter < 100)
        {
            iter++;
        }
        */
        
        if (time >= spawnRate && !first)
        {
            clone = Instantiate(arrow);
            clone.GetComponent<startSpeed>().speed = gameObject.GetComponent<SpeedOfArrow>().moveSpeed;
            clone.GetComponent<Collision2>().score = gameObject;
            time = 0;
            //arrowsCreated += 1;
        } else if (time > wait && superFirst)
        {
            clone = Instantiate(arrow);
            clone.GetComponent<startSpeed>().speed = gameObject.GetComponent<SpeedOfArrow>().moveSpeed;
            clone.GetComponent<Collision2>().score = gameObject;
            time = 0;
            //arrowsCreated += 1;
            superFirst = false;
            first = false;
        } else if (time >= spawnRate * 2 && !superFirst) 
        {
            clone = Instantiate(arrow);
            clone.GetComponent<startSpeed>().speed = gameObject.GetComponent<SpeedOfArrow>().moveSpeed;
            clone.GetComponent<Collision2>().score = gameObject;
            time = 0;
            first = false;
        }
        
    }
}
