using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthSpawn : MonoBehaviour
{
    public GameObject health;
    private GameObject tmp;
    private int i = 0;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        while (i < 10)
        {
            tmp = Instantiate(health);
            tmp.transform.position -= pos;
            pos.x = pos.x + 1.5f;
            i++;
        }
    }
}
