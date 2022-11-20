using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapeZort : MonoBehaviour
{
    public SkinnedMeshRenderer bodySkinnedMeshRenderer;
    public float shapeValue;
    // Start is called before the first frame update
    void Start()
    {
        bodySkinnedMeshRenderer.SetBlendShapeWeight(0, shapeValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (shapeValue <= 0)
        {
            shapeValue = 0;

        }
        if (shapeValue >= 100)
        {
            shapeValue = 100;
        }
        if (LevelController.Current.gameActive)
        {
            shapeValue -= Time.deltaTime * 5;
            bodySkinnedMeshRenderer.SetBlendShapeWeight(0, shapeValue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "arti" )
        {
            
            shapeValue += 20;
            Destroy(other.gameObject);
        }
        else if (other.tag == "eksi")
        {
            shapeValue -= 20;
            Destroy(other.gameObject);
        }
    }
}
