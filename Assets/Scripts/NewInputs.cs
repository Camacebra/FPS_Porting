using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class NewInputs : MonoBehaviour
{
    private InputsActions controls;
    private static NewInputs _instance;
    public static NewInputs instace { get { return _instance;} }
    private void Awake(){
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
        SettingsControllers();
    }
    private void SettingsControllers() {
        controls = new InputsActions();
        controls.Player.Enable();
    }

    public Vector2 GetMovementDirection => controls.Player.Movement.ReadValue<Vector2>();
    public bool JumpDown => controls.Player.Jump.triggered;
    public bool MenuDown => controls.Player.Menu.triggered;
    public bool MapPressed => controls.Player.Map.phase == InputActionPhase.Started;
    public bool RunPressed => controls.Player.Run.phase == InputActionPhase.Started;
    public Vector2 CameraDirection => controls.Player.Camera.ReadValue<Vector2>();
    public bool ShootPressed => controls.Player.Shoot.phase == InputActionPhase.Started;
    public bool ReloadPressed => controls.Player.Reload.phase == InputActionPhase.Started;
    public float SwitchWeapon => controls.Player.SwithWeapon.triggered ?  controls.Player.SwithWeapon.ReadValue<float>() : 0;
    public float SelectWeapon => controls.Player.SelectWeapon.triggered ? controls.Player.SelectWeapon.ReadValue<float>() : 0;

}
