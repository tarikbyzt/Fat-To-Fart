using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoTweenn : MonoBehaviour
{
    public Transform hedef;
    public float zaman;
    void Start()
    {
        if (transform.position.z>=134)
        {
            transform.DOMove(hedef.position, zaman);
            Debug.Log("dotween");
        }

    }
    


}
