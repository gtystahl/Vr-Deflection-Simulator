using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public int frame = 1;
    public int firstStop = 30;
    public int secondStop = 30;
    private Vector3 moveUp;
    private Vector3 startLoc;
    private bool firstMoveDone = false;
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
    // Start is called before the first frame update
    void Start()
    {
        //This gets changes the move to target code to turn on
        //startLoc.x = 0;
        //startLoc.y = 1.5f;
        //startLoc.z = -24;
        //transform.position = startLoc;
        //x +-18
        //y +-45
        //transform.Rotate(270, 0, 0);

        moveUp.y = 3f / 30f;

    }

    // Update is called once per frame
    void Update()
    {
        if (!firstMoveDone && frame <= firstStop )
        {
            transform.position += moveUp;
            frame++;
        } else
        {
            firstMoveDone = true;
        }
        
        if (!targetMove && firstMoveDone)
        {
            gameObject.GetComponent<MoveToTarget>().enabled = true;
            targetMove = true;
        }

        if (!targetStop && gameObject.GetComponent<MoveToTarget>().Tdone)
        {
            //This gets changes the move to target code to turn off
            gameObject.GetComponent<MoveToTarget>().enabled = false;
            arrowX = transform.rotation.eulerAngles.x;
            arrowY = transform.rotation.eulerAngles.y;
            if (arrowX < 18)
            {
                xRotationTarget = 0 - arrowX;
            } else
            {
                xRotationTarget = 0 - (arrowX - 360);
            }
            if (arrowY < 45)
            {
                yRotationTarget = 0 - arrowY;
            } else
            {
                yRotationTarget = 0 - (arrowY - 360);
            }
            xRotChange = xRotationTarget / secondStop;
            yRotChange = yRotationTarget / secondStop;
            targetStop = true;
        }

        else if (gameObject.GetComponent<MoveToTarget>().Tdone)
        {
            if (!secondMoveDone && frame <= firstStop + secondStop)
            {
                transform.Rotate(xRotChange, 0, 0, Space.Self);
                frame++;

            }

            else if (!secondMoveDone && (frame > (firstStop + secondStop) && frame <= firstStop + (secondStop * 2)))
            {
                transform.Rotate(0, yRotChange, 0, Space.Self);
                frame++;
            } else
            {
                secondMoveDone = true;
            }
        }

        if (!playerMove && secondMoveDone)
        {
            gameObject.GetComponent<MoveToPlayer>().enabled = true;
            playerMove = true;
        }

        if (gameObject.GetComponent<MoveToPlayer>().Pdone)
        {
            gameObject.GetComponent<MoveToPlayer>().enabled = false;
        }

    }
}
