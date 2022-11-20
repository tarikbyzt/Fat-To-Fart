using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartZort : MonoBehaviour
{
    public static FartZort Current;
    public float fartingValue = 1000;
    [SerializeField] GameObject fartingEffect;
    public SkinnedMeshRenderer bodySkinnedMeshRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
       
        Current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (LevelController.Current.gameActive)
        {
            
            fartingValue -= Time.deltaTime * 50;
          
            
        }
        if (fartingValue <= 0)
        {
            fartingEffect.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "arti")
        {
            fartingValue += 200;
            Destroy(other.gameObject);
        }
        else if (other.tag == "eksi")
        {
            fartingValue -= 200;
            Destroy(other.gameObject);
        }
    }
}
