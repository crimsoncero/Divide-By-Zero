using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class ZSwordController : MonoBehaviour
{

    [SerializeField] GameObject ExplosionVFX;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Destructible")
        {
            Vector3 pos = collision.gameObject.transform.position + new Vector3(0, 0, -2);
            Instantiate(ExplosionVFX, pos, Quaternion.identity);


            Destroy(collision.gameObject);
        }

    }
    
    
}
