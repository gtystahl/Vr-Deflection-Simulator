using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textCode : MonoBehaviour
{
    public string firstText;
    public string secondText;
    public TextMesh t;
    //public MeshRenderer mr;

    public GameObject spawner;
    // Start is called before the first frame update
    void Start()
    {
        firstText = "Welcome To The Game \n Your Health Is The Red Boxes \n Your Swords Are By Your Sides \n Reach Out To Them, And Grab Them \n With The Force \n Then...Survive";
        t.text = firstText;
        secondText = "If you made it this far congradulations \n Your health will now be restored to 5 \n (if you have lost more than that) \n Now comes the real challenge \n Try to not get DEREZZED";
    }

    // Update is called once per frame
    void Update()
    {
        if (spawner.GetComponent<CreateArrow>().time > 15 && t.text == firstText)
        {
            t.text = "";
        } else if ((spawner.GetComponent<CreateArrow>().superFirst && spawner.GetComponent<keepScore>().totalScore != 0) && (spawner.GetComponent<CreateArrow>().time >= 4 && spawner.GetComponent<CreateArrow>().time <= 19)) {
            t.text = secondText;
        } else if (spawner.GetComponent<CreateArrow>().time > 19 && t.text == secondText)
        {
            t.text = "";
        } 
    }
}
