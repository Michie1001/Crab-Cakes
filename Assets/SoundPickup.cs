using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPickup : MonoBehaviour
{
    public AudioSource munch;

    void Start()
    {
        munch = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plastic"))
        {
            munch.Play();
        }
    }
}