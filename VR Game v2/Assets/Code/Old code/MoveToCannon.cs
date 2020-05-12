using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MoveToCannon : MonoBehaviour
{
    private float arrowX;
    private float arrowY;
    private float xRotation;
    private float yRotation;
    //This bring in the information for the arrow
    public Transform arrow;
    //public Rigidbody rb;

    //This creates the variable for the rotation on the x and y
    public double RotX;
    public double RotY;

    //This creates varaibles for the trig
    public double radianConverter = 180 / Math.PI;
    public float z;
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
    public float cannonLocX;
    public float cannonLocY;
    public float cannonLocZ;

    public bool Cdone = false;
    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;

        moveRate = 120;
        //This sets the player box variables
        cannonLocX = 0;
        cannonLocY = 1.5f;
        cannonLocZ = -24;

        //This switches the direction of the arrow
        //transform.Rotate(180, 0, 0, Space.World);

        arrowX = transform.rotation.eulerAngles.x;
        arrowY = transform.rotation.eulerAngles.y;

        /*
        Debug.Log("This is arrowX ");
        Debug.Log(arrowX);
        Debug.Log("This is arrowY");
        Debug.Log(arrowY);
        */
        //xRotation = 180 - arrowX;
        //yRotation = 0 - arrowY;
        /*
        Debug.Log("This is how much x needs to rotate to get to 180");
        Debug.Log(xRotation);
        Debug.Log("This is how much y needs to rotate to get to 0");
        Debug.Log(yRotation);
        */
        transform.rotation = Quaternion.identity;

        transform.Rotate(180, 0, 0, Space.World);

        x = cannonLocX - transform.position.x;
        y = cannonLocY - transform.position.y;
        z = cannonLocZ - transform.position.z;
 
        //This sets up the total rotation
        RotY = Math.Atan(x / z) * radianConverter;
        RotX = Math.Atan(y / z) * -radianConverter;

        //xRotChange = (float)RotX / rotRate;
        //yRotChange = (float)RotY / rotRate;

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
        /*
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
            Cdone = true;
        }
        */
        //This moves the arrow to the player with the speed determined before
        if (frame == 1)
        {
            transform.Rotate((float)RotX, 0, 0, Space.World);
            Debug.Log(transform.rotation.eulerAngles.z);
        } else if (frame == 10) {
            transform.Rotate(0, (float)RotY, 0, Space.World);
            Debug.Log(transform.rotation.eulerAngles.z);
        } else if (frame > 10 && frame < moveRate + 10)
        {
            transform.position += allMove;
        } else
        {
            Cdone = true;
        }
        frame++;

    }
}
