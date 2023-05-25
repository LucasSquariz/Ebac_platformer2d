using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem itemParticleSystem;

    private void Awake()
    {
        if(itemParticleSystem != null)
        {
            itemParticleSystem.transform.SetParent(null);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect() { 
        gameObject.SetActive(false);
        OnCollect();
    }

    protected virtual void OnCollect() 
    {
        if(itemParticleSystem != null)
        {
            itemParticleSystem.Play();
        }
    }
}
