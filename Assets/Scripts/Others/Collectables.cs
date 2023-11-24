using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


public class Collectables : MonoBehaviour
{   
        public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Bullet"){
            Destroy(gameObject);
            Debug.Log("Broken");

            
        }
    }

    
}
