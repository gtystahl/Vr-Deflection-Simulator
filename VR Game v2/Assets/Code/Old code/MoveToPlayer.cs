using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    //This bring in the information for the arrow
    public Transform arrow;
    //public Rigidbody rb;

    //This creates the variable for the rotation on the x and y
    public double RotX;
    public double RotY;

    //This creates varaibles for the trig
    public double radianConverter = 180 / Math.PI;
    public float z = 25;
    public double y;
    public double x;

    //This is used to set the forces
    public double xChange;
    public double yChange;
    public double zChange;
    public float xRotChange;
    public float yRotChange;

    //This creates the adding vector for the position change
    public Vector3 allMove;

    //This creates an interation varaible
    public int frame = 1;
    public int rotRate = 30;
    public int moveRate = 30;

    //This creates the player box variables
    public float playerBoxX;
    public float playerBoxY;

    public bool Pdone = false;
    public float curY;
    // Start is called before the first frame update
    void Start()
    {

        //This sets the player box variables
        playerBoxX = UnityEngine.Random.Range(-2f, 2f);
        playerBoxY = UnityEngine.Random.Range(-2f, 2f);

        x = playerBoxX - transform.position.x;
        y = playerBoxY - (transform.position.y - 4.5);
        curY = transform.position.y;

        //This sets up the total rotation
        RotY = Math.Atan(x / z) * radianConverter;
        RotX = -(Math.Atan(y / z) * radianConverter);

        xRotChange = (float)RotX / rotRate;
        yRotChange = (float)RotY / rotRate;

        //This changes the change variables
        xChange = x / moveRate;
        yChange = y / moveRate;
        zChange = z / moveRate;

        allMove.x = (float)xChange;
        allMove.y = (float)yChange;
        allMove.z = (float)zChange;
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
            Pdone = true;
        }
        //This moves the arrow to the player with the speed determined before
        frame++;

    }
}
