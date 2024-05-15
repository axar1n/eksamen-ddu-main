using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakableWallScript : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Hammer")) 
        { 
           Destroy(col.gameObject);
           Destroy(gameObject);
        }
    }
}
