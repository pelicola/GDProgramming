using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{   
    public Player player;  
    public void Start(){
        player = FindObjectOfType<Player>(); 
    }
    public void OnCollisionEnter(Collision other){

        if(other.gameObject.tag == "User"){
            player.gunChange(); 
            Destroy(gameObject);
            Debug.Log("Broken");

            
        }
    }

    
}
