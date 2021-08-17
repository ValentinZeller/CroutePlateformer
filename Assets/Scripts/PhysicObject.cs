using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        //Debug.Log(collider.gameObject.name);
        if (collider.gameObject.layer == 8)
        {
            gameObject.layer = 8;
        }

        if(gameObject.CompareTag("Grabbed") && !collider.gameObject.CompareTag("Player")) {
            gameObject.tag = "Untagged";
        }
    }

    void OnCollisionStay2D(Collision2D collider)
    {
        //Debug.Log(collider.gameObject.name);
        if (collider.gameObject.layer == 8)
        {
            gameObject.layer = 8;
        }
    }



    void OnCollisionExit2D(Collision2D collider)
    {
        if (!collider.gameObject.name.Contains("Player"))
        gameObject.layer = 0;
    }
}
