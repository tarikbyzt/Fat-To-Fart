using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public static EnemyScript Current;
    private Transform targetTransform;
    [SerializeField] float enemySpeed;
    [SerializeField] float stopDistance;
    public Animator enemyAnimator;
    public int health = 200;
    [SerializeField] private Color mainColor = Color.green;
    [SerializeField] GameObject stick;



    private void Start()
    {
        Current = this;
        targetTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        
    }
    private void Update()
    {
        if (LevelController.Current == null || !LevelController.Current.gameActive)
        {
            return;
        }
        if (targetTransform != null)
        {
            transform.LookAt(targetTransform);
            float distance = Vector3.Distance(transform.position, targetTransform.position);
            if (distance >= stopDistance)
            {
                transform.position += transform.forward * enemySpeed * Time.deltaTime;// düþmana doðru speed hýzýyla her an hareket et dedik.
            }
        }
    }

    
    private void OnParticleCollision(GameObject other)
    {
        health--;
        if (health <= 0)
        {

            stick.GetComponent<MPBController>().enabled=true;
            LevelController.Current.ChangeScore(2);
            BoxCollider collider = GetComponent<BoxCollider>();
            collider.enabled = !collider.enabled;
            enemyAnimator.SetBool("Running", false);
            enemySpeed = 0;
            StartCoroutine(die());

        }
        Debug.Log("Particle");
    }
    IEnumerator die()
    {

        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
