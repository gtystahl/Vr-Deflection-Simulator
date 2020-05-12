using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MoveToCannon2 : MonoBehaviour
{

    //This bring in the information for the arrow
    public Transform arrow;
    public GameObject arrowSpawner;
    //public Rigidbody rb;

    //This creates the variable for the rotation on the x and y
    public double RotX;
    public double RotY;

    //This creates varaibles for the trig
    public double radianConverter = 180 / Math.PI;
    public float z;
    public double y;
    public double x;

    //This creates the adding vector for the position change
    public Vector3 allMove;

    //This creates the player box variables
    public float cannonLocX;
    public float cannonLocY;
    public float cannonLocZ;

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

    public bool Cdone = false;

    public Vector3 allRotate;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        //moveLength = arrowSpawner.GetComponent<SpeedOfArrow>().moveSpeed;
        //rotateLength = gameObject.GetComponent<SpeedOfArrow>().rotateSpeed;
        moveLength = gameObject.GetComponent<startSpeed>().speed;

        //This sets the player box variables
        cannonLocX = 0;
        cannonLocY = 1.5f;
        cannonLocZ = -24;

        transform.rotation = Quaternion.identity;

        transform.Rotate(180, 0, 0, Space.Self);

        x = cannonLocX - transform.position.x;
        y = cannonLocY - transform.position.y;
        z = cannonLocZ - transform.position.z;

        //This sets up the total rotation
        RotY = Math.Atan(x / z) * radianConverter;
        RotX = Math.Atan(y / z) * radianConverter;

    }


    // Update is called once per frame
    void Update()
    {

        changeTime = Time.deltaTime;

        if (time == 0) {
            //transform.Rotate((float)RotX, (float)RotY, 0, Space.Self);
            allRotate.x = (float)RotX;
            allRotate.y = (float)RotY;
            transform.eulerAngles += allRotate;
        }
        else if (time <= moveLength)
        {
            changeX = (x / moveLength) * changeTime;
            changeY = (y / moveLength) * changeTime;
            changeZ = (z / moveLength) * changeTime;
            allMove.x = (float)changeX;
            allMove.y = (float)changeY;
            allMove.z = (float)changeZ;
            transform.position += allMove;
        }
        else
        {
            Cdone = true;
        }

        time += changeTime;
    }
}
