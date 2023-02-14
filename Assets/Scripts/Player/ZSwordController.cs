using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class ZSwordController : MonoBehaviour
{

    
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Destructible")
        {
            Destroy(collision.gameObject);
        }

    }
    
    
}
