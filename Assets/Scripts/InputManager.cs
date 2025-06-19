using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    [HideInInspector]
    public PlayerInput.OnFootActions onFoot;

    private PlayerMotion motor;
    //private Gun gun;    // FUTURE
    private ThrowingItem throwing;
    private PlayerLook look;
    private PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotion>();
        //gun = GetComponent<Gun>();     // FUTURE
        throwing = GetComponent<ThrowingItem>();
        look = GetComponent<PlayerLook>();
        pauseMenu = GetComponent<PauseMenu>();

        onFoot.Jump.performed += ctx => motor.Jump();
        //onFoot.Sprint.performed += ctx => motor.Sprint();
        onFoot.Crouch.performed += ctx => motor.Crouch();
        //onFoot.Shoot.performed += ctx => gun.Shoot();     // FUTURE
        onFoot.PauseMenu.performed += ctx => pauseMenu.togglePauseMenu();
        //onFoot.Sniper.performed += ctx => gun.Sniper();   // FUTURE
        onFoot.Throwing.performed += ctx => throwing.Throw();
        onFoot.OpenShop.performed += ctx => pauseMenu.toggleShopMenu();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell player move using the value from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
