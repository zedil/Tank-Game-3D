using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : Sense
{
    public override void InitializeSense()
    {
        
    }

    public override void UpdateSense()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.Equals("player"))
        {
            fsm.SetBool("isVisible", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        fsm.SetBool("isVisible", false);
    }
}
