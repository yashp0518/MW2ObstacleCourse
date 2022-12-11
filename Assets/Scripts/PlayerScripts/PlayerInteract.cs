using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    public float distance = 3f;
    public LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        //assigning this cam instance to the same as playerLook
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();

    }

    void Update()
    {
        playerUI.updateText(string.Empty);
        //ray allowing us to detect collisions
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        //store collision info
        RaycastHit hitInfo;
        //see if we hit anything on given layer
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            //checks to see if gameObject has interactable component
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                //if so, store interactable in variable
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.updateText(interactable.messagePrompt);
                //everytime player changes state of interact action
                if (inputManager.onFoot.Interact.triggered)
                {
                    interactable.baseInteract();
                }
            }
        }

    }
}
