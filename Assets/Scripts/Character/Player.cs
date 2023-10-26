using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TMPro; 
[RequireComponent(typeof(Rigidbody))]

public class Player : MonoBehaviour
{
    public TextMeshProUGUI ammoInfoText, totalAmmoText, noAmmoText; 
    [SerializeField, Range (1,20)] private float mouseSensX; 
    [SerializeField, Range (1,20)] private float mouseSensY; 
    [SerializeField, Range (-90,0)] private float minViewAngle; 
    [SerializeField, Range (0,90)] private float maxViewAngle; 
    [SerializeField] private Transform followTarget; 
    
    private Vector2 currentAngle; 


    //Shooting
    [SerializeField] private Rigidbody bulletPrefab; 
    [SerializeField] private float projectileForce; 
    public int currentClip; //How much loaded in the gun right now
    public int maxClipSize; //How much the gun can hold
    public int currentAmmo; //Current ammo from player
    public int maxAmmoSize; //Number of ammos that player can hold

    public bool nextThing; 

    private float speed = 10;
    private float jumpForce = 2.0f; 
    private bool isGrounded;
    private Vector3 _moveDirection;
    private Rigidbody rb;
    void Start()
    {
        InputManager.InIt(myPlayer:this);
        InputManager.SetGameControls();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (currentClip == 0){
            noAmmoText.gameObject.SetActive(true);
            nextThing = true; 

        }


        if (nextThing == true && Input.GetKeyDown(KeyCode.R)){
            noAmmoText.gameObject.SetActive(false);
        }


        ammoInfoText.text = currentClip + " / " + maxClipSize; 
        totalAmmoText.text = " " + currentAmmo; 
        transform.position += transform.rotation* (speed * Time.deltaTime * _moveDirection);
        CheckGround(); 
    }


    public void SetMovementDirection(Vector3 currentDirection){

        _moveDirection = currentDirection;
    }

    public void Jump(){
        Debug.Log("Jump Call");
        
        if (isGrounded){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }
    }

    private void CheckGround(){
        isGrounded = Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.size.y);
        Debug.DrawRay(transform.position, Vector3.down * GetComponent<Collider>().bounds.size.y, Color.green, duration:0, depthTest:false);
    }


    public void SetLookRotation(Vector2 readValue){
        currentAngle.x  += readValue.x * Time.deltaTime * mouseSensX; 
        currentAngle.y  += readValue.y * Time.deltaTime * mouseSensY; 

        currentAngle.y = Mathf.Clamp(currentAngle.y, minViewAngle, maxViewAngle); 
        
        transform.rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up);
        followTarget.localRotation = Quaternion.AngleAxis(currentAngle.y, Vector3.right);

    }

    public void Shoot(){

        if (currentClip > 0){

        Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity); 

        currentProjectile.AddForce(followTarget.forward * projectileForce, ForceMode.Impulse); 

        Destroy(currentProjectile.gameObject, 4);

        currentClip--; 

        }

    }


    public void Reload(){
        int reloadAmount = maxClipSize - currentClip; 
        reloadAmount = Mathf.Min(maxClipSize - currentClip, currentAmmo); 
        currentClip += reloadAmount; 
        currentAmmo -= reloadAmount; 
    }

}