using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

//Fix rotation for the 100th time

public class MoveToTarget2 : MonoBehaviour
{
    public bool Tdone = false;
    public GameObject arrowSpawner;

    //This bring in the information for the arrow
    public Transform arrow;

    //This creates the variable for the rotation on the x and y
    private int RotX;
    private int RotY;

    //This creates varaibles for the trig
    private double radianConverter = Math.PI / 180;
    private int z = 9;
    private double y;
    private double x;

    //This creates varaibles for telling top or bottom of the four triangles
    private bool topTriRotX;
    private bool topTriRotY;

    //This creates an interation varaible
    public float moveLength;
    //public float rotateLength;

    //This creates the time variables
    public float time;
    private float changeTime;

    //This creates the changing rotation and movement variables
    public double changeX;
    public double changeY;
    public double changeZ;
    public double changeRotX;
    public double changeRotY;

    //This creates the adding vector for the position change
    private Vector3 allMove;
    private Vector3 allRotate;

    // Start is called before the first frame update
    void Start()
    {
        //Change all of the gameobjects to the arrow creator object
        time = 0;
        //moveLength = arrowSpawner.GetComponent<SpeedOfArrow>().moveSpeed;
        //rotateLength = gameObject.GetComponent<SpeedOfArrow>().rotateSpeed;
        moveLength = gameObject.GetComponent<startSpeed>().speed;

        topTriRotX = true;
        topTriRotY = true;

        //This sets the X rotation to an integer 
        RotX = UnityEngine.Random.Range(0, 36);

        //This checks to see if the random int is bigger or smaller than 18 to determine the top or the bottom of the triangle
        if (RotX <= 18)
        {
            //This works some trig magic and sets y = to what the opposite side would be
            y = (z * (Math.Tan(RotX * radianConverter)));
        }
        else
        {
            //This makes the rot into the simple triangle
            RotX = RotX - 18;

            //This tells the computer that we are using bottom triangle
            topTriRotX = false;

            //This is same as if
            y = (z * (Math.Tan(RotX * radianConverter)));
        }

        //This sets the Y rotation to an integer
        RotY = UnityEngine.Random.Range(0, 90);

        //This checks to see if the random int is smaler than 45 to determine top or bottom of the triangle
        if (RotY <= 45)
        {
            //This works some more trig magic with the help of the other trig
            x = (z * Math.Tan(RotY * radianConverter));

        }
        else
        {
            //This makes the rot into the simple triangle
            RotY = RotY - 45;

            //This tells the computer that we are using bottom triangle
            topTriRotY = false;

            //This is same as other
            x = (z * Math.Tan(RotY * radianConverter));
        }
       // Debug.Log(RotX);
       // Debug.Log(topTriRotX);
        //Debug.Log(RotY);
        //Debug.Log(topTriRotY);

    }


    // Update is called once per frame
    void Update()
    {
        changeTime = Time.deltaTime;

        if (time == 0)
        {
            if (topTriRotX)
            {
                //changed this to be instantaneous
                //changeRotX = -(RotX / rotateLength) * changeTime;
                changeRotX = -RotX;
            }
            else
            {
                //changeRotX = (RotX  / rotateLength) * changeTime;
                changeRotX = RotX;
            }
            allRotate.x = (float)changeRotX;
            //transform.Rotate((float)changeRotX, 0, 0, Space.Self);

            if (topTriRotY)
            {
                //Debug.Log("This should rotate");
                changeRotY = RotY;
            }
            else
            {
                //Debug.Log("This should rotate");
                changeRotY = -RotY;
            }

            allRotate.y = (float)changeRotY;
            //transform.Rotate(0, (float)changeRotY, 0, Space.Self);
            transform.eulerAngles += allRotate; 
        }
        else if (time <= moveLength)
        {
            if (topTriRotY)
            {
                changeX = (x / moveLength) * changeTime;
            }
            else
            {
                changeX = -(x / moveLength) * changeTime;
            }

            if (topTriRotX)
            {
                changeY = (y / moveLength) * changeTime;
            }
            else
            {
                changeY = -(y / moveLength) * changeTime;
            }

            changeZ = (z / moveLength) * changeTime;

            allMove.x = (float)changeX;
            allMove.y = (float)changeY;
            allMove.z = (float)changeZ;

            transform.position += allMove;
        }
        else
        {
            Tdone = true;
        }

        time += changeTime;
    }
}
