using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public GameObject spawner;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject five;
    public GameObject six;
    public GameObject seven;
    public GameObject eight;
    public GameObject nine;
    public GameObject ten;

    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
    }

    private void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "arrow")
        {
            health--;
        }
    }

    private void Update()
    {
        if (health == 9)
        {
            Destroy(ten);
        }
        else if (health == 8)
        {
            Destroy(nine);
        }
        else if (health == 7)
        {
            Destroy(eight);
        }
        else if (health == 6)
        {
            Destroy(seven);
        }
        else if (health == 5)
        {
            five.GetComponent<MeshRenderer>().enabled = true;
            Destroy(six);
        }
        else if (health == 4)
        {
            //Destroy(five);
            four.GetComponent<MeshRenderer>().enabled = true;
            five.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (health == 3)
        {
            //Destroy(four);
            three.GetComponent<MeshRenderer>().enabled = true;
            four.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (health == 2)
        {
            //Destroy(three);
            two.GetComponent<MeshRenderer>().enabled = true;
            three.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (health == 1)
        {
            //Destroy(two);
            two.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (health == 0)
        {
            //Destroy(one);
            one.GetComponent<MeshRenderer>().enabled = false;
            spawner.GetComponent<CreateArrow>().enabled = false;
        }
    }
}
