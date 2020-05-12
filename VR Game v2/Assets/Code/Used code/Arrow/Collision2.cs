using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision2 : MonoBehaviour
{
    // Update is called once per frame
    public GameObject score;
    /*
    private void Start()
    {
        //score = GameObject.FindWithTag("spawner");
    }
    */
    void OnCollisionEnter(UnityEngine.Collision collisionInfo)
    {
        //Debug.Log("This collides with anything");
        //change back to sword
        if (collisionInfo.collider.tag == "sword")
        {
            //Debug.Log("This collided with the object");
            gameObject.GetComponent<ControllerScript2>().enabled = false;
            gameObject.GetComponent<MoveToPlayer2>().enabled = false;
            gameObject.GetComponent<MoveToTarget2>().enabled = false;
            gameObject.GetComponent<MoveToCannon2>().enabled = true;

        }
        else if (collisionInfo.collider.tag == "arrow")
        {
            Debug.Log("The arrows collided");
            gameObject.GetComponent<ControllerScript2>().enabled = false;
            gameObject.GetComponent<MoveToPlayer2>().enabled = false;
            gameObject.GetComponent<MoveToTarget2>().enabled = false;
            score.GetComponent<keepScore>().totalScore++;
            Destroy(this.gameObject);

        }
        else if (gameObject.GetComponent<ControllerScript2>().firstMoveDone && collisionInfo.collider.name == "cannon")
        {
            Debug.Log("The arrow came back to the cannon");
            gameObject.GetComponent<ControllerScript2>().enabled = false;
            gameObject.GetComponent<MoveToPlayer2>().enabled = false;
            gameObject.GetComponent<MoveToTarget2>().enabled = false;
            Destroy(this.gameObject);
        } else if (collisionInfo.collider.name == "playerHit")
        {
            Debug.Log("The arrow hit the player");
            gameObject.GetComponent<ControllerScript2>().enabled = false;
            gameObject.GetComponent<MoveToPlayer2>().enabled = false;
            gameObject.GetComponent<MoveToTarget2>().enabled = false;
            Destroy(this.gameObject);
        }
    }
}
