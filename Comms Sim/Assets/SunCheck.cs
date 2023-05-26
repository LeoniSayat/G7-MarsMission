using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunCheck : MonoBehaviour
{
   
    // void OnTriggerEnter2D(Collider2D other)
    // {
       
    //         //If the GameObject's name matches the one you suggest, output this message in the console
    //         Debug.Log("Do something here");
        
    // }

    void OnCollisionStay2D(Collision2D collision){
        if (collision.gameObject.name == "SunCollider"){
            Debug.Log("Test");
        }
        
    }
}
