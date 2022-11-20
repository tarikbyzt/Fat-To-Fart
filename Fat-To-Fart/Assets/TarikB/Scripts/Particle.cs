using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    [SerializeField] GameObject part;
    public int health = 100;
    private void OnParticleCollision(GameObject other)
    {
        health--;
        if (health<=0)
        {
            Destroy(gameObject);
        }
        
        Debug.Log("particle ");
    }

}
