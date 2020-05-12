using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Update is called once per frame
    void OnCollisionEnter(UnityEngine.Collision collisionInfo) 
    {
        //Debug.Log("This collides with anything");
        //change back to sword
        if (collisionInfo.collider.name == "object" )
        {
            //Debug.Log("This collided with the object");
            gameObject.GetComponent<ControllerScript>().enabled = false;
            gameObject.GetComponent<MoveToPlayer>().enabled = false;
            gameObject.GetComponent<MoveToTarget>().enabled = false;
            gameObject.GetComponent<MoveToCannon>().enabled = true;

        } else if (collisionInfo.collider.tag == "arrow")
        {
            Debug.Log("The arrows collided");
            gameObject.GetComponent<ControllerScript>().enabled = false;
            gameObject.GetComponent<MoveToPlayer>().enabled = false;
            gameObject.GetComponent<MoveToTarget>().enabled = false;
            Destroy(this.gameObject);

        } else if (collisionInfo.collider.name == "cannon")
        {
            Debug.Log("The arrow came back to the cannon");
            gameObject.GetComponent<ControllerScript>().enabled = false;
            gameObject.GetComponent<MoveToPlayer>().enabled = false;
            gameObject.GetComponent<MoveToTarget>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}
