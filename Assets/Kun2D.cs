using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kun2D : MonoBehaviour
{
    public PlayerMovement pm;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        pm.is3DToggle = false;
        pm.is3D = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pm.is3DToggle = true;
    }


}
