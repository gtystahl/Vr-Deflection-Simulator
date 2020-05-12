using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript2 : MonoBehaviour
{
    public GameObject arrowSpawner;
    private Vector3 moveUp;
    public bool firstMoveDone = false;
    private bool secondMoveDone = false;
    private bool targetMove = false;
    private float xRotationTarget;
    private float yRotationTarget;
    private float xRotChange;
    private float yRotChange;
    private bool targetStop = false;
    private bool playerMove = false;

    private float arrowX;
    private float arrowY;

    //This creates an interation varaible
    public float moveLength;
    //public float rotateLength;

    //This creates the time variables
    public float time;
    private float changeTime;

    //This creates the vector to store the rotation values
    public Vector3 firstRotate;
    public Vector3 secondRotate;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        //moveLength = arrowSpawner.GetComponent<SpeedOfArrow>().moveSpeed;
        //rotateLength = gameObject.GetComponent<SpeedOfArrow>().rotateSpeed;
        moveLength = gameObject.GetComponent<startSpeed>().speed;
        //rotateLength = .5f;
    }

    // Update is called once per frame
    void Update()
    {
        changeTime = Time.deltaTime;

        if (!firstMoveDone && time <= moveLength)
        {
            moveUp.y = (3f / moveLength) * changeTime;
            transform.position += moveUp;
            time += changeTime;
        } else if (!firstMoveDone && time > moveLength)
        {
            //I changed the else if to only run once
            //I changed the rotation to be instantaneous
            //I got rid of the seperate else statement for the firstMoveDone
            //firstRotate = (90f / rotateLength) * changeTime;
            //transform.Rotate(firstRotate, 0, 0, Space.Self);
            firstRotate.x = 0f;
            transform.eulerAngles = firstRotate;
            time += changeTime;
            firstMoveDone = true;
        }

        if (!targetMove && firstMoveDone)
        {
            gameObject.GetComponent<MoveToTarget2>().enabled = true;
            targetMove = true;
            time = 0;
        }

        if (!targetStop && gameObject.GetComponent<MoveToTarget2>().Tdone)
        {
            //This gets changes the move to target code to turn off
            gameObject.GetComponent<MoveToTarget2>().enabled = false;
            arrowX = transform.rotation.eulerAngles.x;
            arrowY = transform.rotation.eulerAngles.y;
            if (arrowX < 18)
            {
                xRotationTarget = 0 - arrowX;
            }
            else
            {
                xRotationTarget = 0 - (arrowX - 360);
            }
            if (arrowY < 45)
            {
                yRotationTarget = 0 - arrowY;
            }
            else
            {
                yRotationTarget = 0 - (arrowY - 360);
            }
            //Changed this as well
            //xRotChange = (xRotationTarget / rotateLength) * changeTime;
            //yRotChange = (yRotationTarget / rotateLength) * changeTime;
            xRotChange = xRotationTarget;
            yRotChange = yRotationTarget;
            secondRotate.x = xRotChange;
            secondRotate.y = yRotChange;
            targetStop = true;
        }

        else if (gameObject.GetComponent<MoveToTarget2>().Tdone)
        {
            if (!secondMoveDone)
            {
                //transform.Rotate(xRotChange, 0, 0, Space.Self);

                //transform.Rotate(0, yRotChange, 0, Space.Self);
                transform.eulerAngles += secondRotate;
                secondMoveDone = true;

            }
        }

        if (!playerMove && secondMoveDone)
        {
            gameObject.GetComponent<MoveToPlayer2>().enabled = true;
            playerMove = true;
        }

        if (gameObject.GetComponent<MoveToPlayer2>().Pdone)
        {
            gameObject.GetComponent<MoveToPlayer2>().enabled = false;
        }

    }
}
