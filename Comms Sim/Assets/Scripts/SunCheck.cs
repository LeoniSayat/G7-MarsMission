using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCheck : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
       
            //If the GameObject's name matches the one you suggest, output this message in the console
            if (other.gameObject.name == "LineDrawer"){
            Debug.Log(other.gameObject.name);
        }
        
    }

    void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.name == "LineDrawer"){
            Debug.Log(collision.gameObject.name);
        }
        
    }
}
