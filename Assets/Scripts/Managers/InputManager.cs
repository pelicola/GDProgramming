using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    private static GameControls _gamecontrols;
    public static void InIt(Player myPlayer){

        _gamecontrols = new GameControls(); 

        _gamecontrols.Permanent.Enable();

        _gamecontrols.InGame.Movement.performed += jeff => {
            myPlayer.SetMovementDirection(jeff.ReadValue<Vector3>());
        };

        _gamecontrols.InGame.Jump.performed += hello => {
            Debug.Log("Hello");
            myPlayer.Jump();
        };

        _gamecontrols.InGame.Shooting.started += ctx => {
           
            myPlayer.Shoot();
            Debug.Log("Shooting");
        };

        _gamecontrols.InGame.Look.performed += ctx => {
            
            myPlayer.SetLookRotation(ctx.ReadValue<Vector2>());
        };

        _gamecontrols.InGame.Reload.performed += ctx => {
            
            myPlayer.Reload(); 
            Debug.Log("Reloading");
        };

    }

    public static void SetGameControls(){

        _gamecontrols.InGame.Enable();
        _gamecontrols.UI.Disable();

    }

    public static void SetUIControls(){

        _gamecontrols.UI.Enable();
        _gamecontrols.InGame.Disable();

    }
}