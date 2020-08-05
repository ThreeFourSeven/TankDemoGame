using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoParticleSystem : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration*1.5f);
    }
}
