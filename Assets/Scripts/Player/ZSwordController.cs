using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;

public class ZSwordController : MonoBehaviour
{

    public bool IsEnabled { get; set; }



    [SerializeField] private BoxCollider2D SwordCollider;
    [SerializeField] private Animator SwordAnimController;
    [SerializeField] private GameObject ExplosionVFX;
    [SerializeField] private AudioSource SwordSFX;


    public void Attack(int duration)
    {
        SwordCollider.enabled = true;
        SwordAnimController.SetTrigger("AttackTrigger");
        SwordSFX.Play();
        StartCoroutine(ZSwordDuration(duration));
    }

    private IEnumerator ZSwordDuration(int duration)
    {
        if (SwordCollider.isActiveAndEnabled)
        {
            for (int i = 0; i < duration; i++)
            {
                yield return new WaitForFixedUpdate();
            }
            SwordCollider.enabled = false;
        }

    }


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
