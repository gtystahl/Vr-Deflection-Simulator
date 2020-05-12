using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScore : MonoBehaviour
{
    public GameObject spawner;
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.tag == "arrow")
        {
            spawner.GetComponent<keepScore>().totalScore++; 
        }
    }
}
