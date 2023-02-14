using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionVFX : MonoBehaviour
{
    [SerializeField] ParticleSystem ExplosionParticleSys;

    private void Awake()
    {
        float totalDuration = ExplosionParticleSys.main.duration + ExplosionParticleSys.main.startLifetime.constantMax;
        Destroy(this.gameObject, totalDuration);
    }
}
