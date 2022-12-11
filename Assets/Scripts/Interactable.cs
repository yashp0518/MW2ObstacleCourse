using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//template for objects to use during the game
public abstract class Interactable : MonoBehaviour
{
    public string messagePrompt;


    //allows player to define how they interact without messing with inner class
    public void baseInteract() {
        Interact();
    }

    //objects that inherit this class will use this however necessary
    protected virtual void Interact() {}



}
