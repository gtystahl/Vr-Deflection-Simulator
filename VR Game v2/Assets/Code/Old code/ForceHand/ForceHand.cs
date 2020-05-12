using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceHand : MonoBehaviour
{
    public Transform handTransform;
    public OVRInput.Controller Controller = OVRInput.Controller.LTouch;

    //private GameObject[] swords;

    private OVRInput.Button TriggerButton;
    private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ForceHands activated!");
        //swords = GameObject.FindGameObjectsWithTag("sword");

        if (Controller == OVRInput.Controller.LTouch)
        {
            TriggerButton = OVRInput.Button.Four;
        }
        else
        {
            TriggerButton = OVRInput.Button.Two;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(TriggerButton))
        {
            Debug.Log("Button PRESSED!");
            // Find the nearest sword and move it closer to handTransform.
            // If there is no sword in range, do nothing.
            RaycastHit[] hits = Physics.SphereCastAll(handTransform.position, 1f, handTransform.forward);
            
            foreach(RaycastHit hit in hits)
            {
       
                string hitTag = hit.transform.gameObject.tag;
                if (hitTag == "sword")
                {
                    GameObject sword = hit.transform.gameObject;
                    Debug.Log("Found a sword... it is " + sword.name);
                    float step = speed * Time.deltaTime;
                    sword.transform.position = Vector3.MoveTowards(sword.transform.position, handTransform.position, step);
                    break;
                }
            }


        }
    }
}
