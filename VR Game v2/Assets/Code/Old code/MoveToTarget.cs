using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public bool Tdone = false;

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

    //This is used to set the forces
    private double xChange = 0;
    private double yChange = 0;
    private double zChange = 0;
    private float xRotChange;
    private float yRotChange;

    //This creates the adding vector for the position change
    private Vector3 allMove;
    private Vector3 allRotate;

    //This creates an interation varaible
    private int frame = 1;
    public int rotRate = 30;
    public int moveRate = 30;

    // Start is called before the first frame update
    void Start()
    {
        topTriRotX = true;
        topTriRotY = true;

        //This sets the X rotation to an integer 
        RotX = UnityEngine.Random.Range(0, 36);

        //This checks to see if the random int is bigger or smaller than 18 to determine the top or the bottom of the triangle
        if (RotX <= 18)
        {
            //This works some trig magic and sets y = to what the opposite side would be
            y = (z * (Math.Tan(RotX * radianConverter)));
        } else
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

        } else
        {
            //This makes the rot into the simple triangle
            RotY = RotY - 45;

            //This tells the computer that we are using bottom triangle
            topTriRotY = false;

            //This is same as other
            x = (z * Math.Tan(RotY * radianConverter));
        }

        //This changes the change variables
        xChange = x / moveRate;
        yChange = y / moveRate;
        zChange = 9.0 / moveRate;

        if (topTriRotX)
        {
            xRotChange = (90 - float.Parse(RotX.ToString())) / rotRate;
        } else
        {
            xRotChange = (float.Parse(RotX.ToString()) + 90) / rotRate;
        }

        if (topTriRotY)
        {
            yRotChange = (float.Parse(RotY.ToString())) / rotRate;
        } else
        {
            yRotChange = -(float.Parse(RotY.ToString())) / rotRate;
        }

        //This sets the movement and rotation amount
        if (topTriRotY)
        {
            allMove.x = (float.Parse(xChange.ToString()));
        } else
        {
            allMove.x = -(float.Parse(xChange.ToString()));
        }

        if (topTriRotX)
        {
            allMove.y = (float.Parse(yChange.ToString()));
        }
        else
        {
            allMove.y = -(float.Parse(yChange.ToString()));
        }

        allMove.z = (float.Parse(zChange.ToString()));

        allRotate.x = xRotChange;
        allRotate.y = yRotChange;


    }


    // Update is called once per frame
    void Update()
    {
        //This moves the arrow to the target with changing speeds based on what I input
        if (frame < rotRate + 1)
        {
            transform.Rotate(xRotChange, 0, 0, Space.World);
        } 

        else if ((frame > rotRate) && (frame < (rotRate * 2) + 1))
        {
            transform.Rotate(0, yRotChange, 0, Space.World);
        }

        else if ((frame > rotRate * 2) && (frame < (rotRate * 2) + moveRate))
        {
            transform.position += allMove;
        } 

        else
        {
            Tdone = true;
        }
        //This moves the arrow to the player with the speed determined before
        frame++;
 
    }
}
