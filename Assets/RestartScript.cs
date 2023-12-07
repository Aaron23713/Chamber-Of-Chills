using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RestartScript : MonoBehaviour
{
    public InputActionAsset inputActions;
    public Canvas canvas;
    public InputAction menu;
    public GameObject menuObject;

    

    // Start is called before the first frame update
    void Start()
    {
        
        menu = inputActions.FindActionMap("XRI LeftHand").FindAction("Menu");
        menu.performed += ToggleMenu;
    }

    private void OnEnable()
    {
        // Enable the input action when the script is enabled
        menu.Enable();
    }

    private void OnDisable()
    {
        // Disable the input action when the script is disabled
        menu.Disable();
    }

    private void OnDestroy()
    {
        menu.performed -= ToggleMenu;
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        
        
    bool newState = !canvas.enabled;
    canvas.enabled = newState;
    menuObject.SetActive(newState);
    }
}
