using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisplay : MonoBehaviour
{
    public string sd;
    public GameObject cube;
    public TextMesh t;

    // Start is called before the first frame update
    void Start()
    {
        sd = cube.GetComponent<transferScore>().score.ToString();
        t.text = sd;
    }
}
