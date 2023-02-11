using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    [SerializeField] Transform PlatformBase;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float xPos = transform.position.x + PlatformBase.lossyScale.x;
        Vector3 pos = new Vector3(xPos, -0.5f, 0);


        GameManager.Instance.NextPlatform(pos);
        gameObject.SetActive(false);

    }
}
