using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //override interact with desired functionality of this object
    protected override void Interact()
    {
        Debug.Log("Interacted with" + gameObject.name);
    }
}
