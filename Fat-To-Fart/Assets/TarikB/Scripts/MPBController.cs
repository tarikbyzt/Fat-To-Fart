using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MPBController : MonoBehaviour
{
    [SerializeField] private Color mainColor = Color.green;

    private Renderer renderer = null;
    private MaterialPropertyBlock materialPropertyBlock = null;

    private void Start()
    {


        renderer = GetComponent<Renderer>();
        materialPropertyBlock = new MaterialPropertyBlock();
    }

    private void Update()
    {

        
        
            Debug.Log("shadering");
            materialPropertyBlock.SetColor("_Color", mainColor);
            renderer.SetPropertyBlock(materialPropertyBlock);
        
            
      

    }

}
