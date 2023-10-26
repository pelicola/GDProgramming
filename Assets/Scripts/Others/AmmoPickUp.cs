using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{    

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Player"){
            
            Score ScoreScript = gameObject.GetComponent<Score>();
            Destroy(gameObject);
            ScoreScript.AddScore();
            Debug.Log("Broken");

            
        }
    }

    
}
