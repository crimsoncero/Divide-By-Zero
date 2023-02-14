using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObseticle : MonoBehaviour
{
    [SerializeField] GameObject ExplosionVFX;

    private void OnDestroy()
    {
        Debug.Log("Died");
        Vector3 pos = transform.position + new Vector3(0, 0, -2);
        Instantiate(ExplosionVFX, pos, transform.rotation);
    }
}
