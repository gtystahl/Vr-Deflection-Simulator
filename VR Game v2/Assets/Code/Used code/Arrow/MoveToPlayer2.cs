using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MoveToPlayer2 : MonoBehaviour
{
    //This bring in the information for the arrow
    public Transform arrow;
    public GameObject arrowSpawner;

    //This creates the variable for the rotation on the x and y
    public double RotX;
    public double RotY;

    //This creates varaibles for the trig
    public double radianConverter = 180 / Math.PI;
    public float z = 25;
    public double y;
    public float x;


    //This creates the adding vector for the position change
    public Vector3 allMove;

    //This creates an interation varaible
    public float moveLength;
    //public float rotateLength;

    //This creates the time variables
    public float time;
    private float changeTime;

    //This creates the changing rotation and movement variables
    public float changeX;
    public double changeY;
    public double changeZ;
    public double changeRotX;
    public double changeRotY;

    //This creates the player box variables
    public float playerBoxX;
    public float playerBoxY;

    public bool Pdone = false;
    // Start is called before the first frame update

    public Vector3 allRotate;
    void Start()
    {
        //This sets the time varaibles
        time = 0;

        //This sets the amount of time it takes for an objext to move and rotate to where it needs to
        //moveLength = arrowSpawner.GetComponent<SpeedOfArrow>().moveSpeed;
        //rotateLength = gameObject.GetComponent<SpeedOfArrow>().rotateSpeed;
        moveLength = gameObject.GetComponent<startSpeed>().speed;

        //This sets the player box variables
        playerBoxX = UnityEngine.Random.Range(-1f, 1.5f);
        playerBoxY = UnityEngine.Random.Range(-1f, 1.5f);

        x = playerBoxX - transform.position.x;
        y = playerBoxY - (transform.position.y - 4.5);

        //This sets up the total rotation
        RotY = Math.Atan(x / z) * radianConverter;
        RotX = -(Math.Atan(y / z) * radianConverter);

    }


    // Update is called once per frame
    void Update()
    {
        changeTime = Time.deltaTime;

        if (time == 0)
        {
            //changeRotX = (RotX / rotateLength) * changeTime;
            changeRotX = RotX;
            //transform.Rotate((float)changeRotX, 0, 0, Space.Self);
            //changeRotY = (RotY / rotateLength) * changeTime;
            changeRotY = RotY;
            //transform.Rotate(0, (float)changeRotY, 0, Space.Self);
            allRotate.x = (float.Parse(changeRotX.ToString()));
            allRotate.y = (float.Parse(changeRotY.ToString()));
            transform.eulerAngles += allRotate;
        } else if (time <= moveLength)
        {
            changeX = (x / moveLength) * changeTime;
            changeY = (y / moveLength) * changeTime;
            changeZ = (z / moveLength) * changeTime;
            allMove.x = changeX;
            allMove.y = (float)changeY;
            allMove.z = (float)changeZ;
            transform.position += allMove;
        } else
        {
            Pdone = true;
        }

        time += changeTime;
    }
}
