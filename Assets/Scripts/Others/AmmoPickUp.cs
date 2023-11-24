using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{   
    public Player player;  
    public void Start(){
        player = FindObjectOfType<Player>(); 
    }
    public void OnCollisionEnter(Collision other){

        if(other.gameObject.tag == "User"){
            player.AddAmmoForPickUp(); 
            Destroy(gameObject);
            Debug.Log("Broken");

            
        }
    }

    
}
