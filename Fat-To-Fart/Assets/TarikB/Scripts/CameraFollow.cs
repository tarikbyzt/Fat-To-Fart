using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float camerafollowSpeed = 5f;

    private Vector3 offsetvector;
    void Start()
    {
        //kameran�n pozisyonundan topun pozisyonunu ��kar�p aradaki fark� buluyoruz.
        //offsetvector = transform.position - target.position;
        //Bunun yerine �a��da yazd���m�z metodu kullanabiliriz
        offsetvector = CalculateOffset(target);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTheCamera();
    }

    private void MoveTheCamera()
    {
        //kameran�n takip edebilmesi i�in kameran�n pozisyonunu, topun pozisyonu ile aradaki farkla topluyoruz 
        //transform.position = target.position + offsetvector;
        Vector3 targetToMove = target.position + offsetvector;
        transform.position = Vector3.Lerp(transform.position, targetToMove, camerafollowSpeed * Time.deltaTime);
        transform.LookAt(target.transform.position);
    }
    private Vector3 CalculateOffset(Transform newTarget)
    {
        return transform.position - newTarget.position;
    }
}
