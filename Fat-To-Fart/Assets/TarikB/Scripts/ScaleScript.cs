using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class ScaleScript : MonoBehaviour
{
    public static ScaleScript Current;
    [SerializeField] private GameObject player;
    [SerializeField] private Material dressMat;
    [SerializeField] private float scaleValue;
    public SkinnedMeshRenderer bodySkinnedMeshRenderer;
    public float scoreX;
    private float dressValue = 100;
    public GameObject censored;
    public Animator coinAnimator;
    public GameObject dancer;
    







    private void Start()
    {
        bodySkinnedMeshRenderer.SetBlendShapeWeight(0, dressValue);
        Current = this;
        
    }
    private void Awake()
    {
        dressMat.color = Color.white;
        //bodySkinnedMeshRenderer.SetBlendShapeWeight(0, dressValue);
    }

    private void Update()
    {
        

        if (LevelController.Current.gameActive)
        {
            dressValue -= Time.deltaTime * 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ScoreX")
        {
            scoreX = (100 - bodySkinnedMeshRenderer.GetBlendShapeWeight(0)) / 10;
            Debug.Log(scoreX);
        }
        if (other.tag == "coin")
        {
            coinAnimator.SetTrigger("Coining");
            //coinAnimator.SetBool("CoinAlma", true);
            Destroy(other.gameObject);
            LevelController.Current.ChangeScore(10);

        }


        

        



        

        if (other.tag == "Green" || other.tag == "Blue" || other.tag == "Red")
        {



            if (other.tag == player.tag)
            {
                Debug.Log("Büyüdü" + player.tag);
                Destroy(other.gameObject);
                if (dressValue > 0)
                {
                    dressValue -= 10;
                }


                bodySkinnedMeshRenderer.SetBlendShapeWeight(0, dressValue);
                //transform.localScale = new Vector3(transform.lossyScale.x + scaleValue * Time.deltaTime, transform.lossyScale.y + scaleValue * Time.deltaTime, transform.lossyScale.z + scaleValue * Time.deltaTime);
                // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


            }




            else
            {
                Debug.Log("Küçüldü");
                Destroy(other.gameObject);
                if (dressValue <= 110)
                {
                    dressValue += 10;
                }

                bodySkinnedMeshRenderer.SetBlendShapeWeight(0, dressValue);
                //transform.localScale = new Vector3(transform.lossyScale.x - scaleValue * Time.deltaTime, transform.lossyScale.y - scaleValue * Time.deltaTime, transform.lossyScale.z - scaleValue * Time.deltaTime);
                //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            }
        }



        if (other.tag == "finish")
        {
           
            //PlayerController.Current.limitX = 0;
            if (dressValue > 100)
            {
                PlayerController.Current.playerAnimator.SetBool("Running", false);
                PlayerController.Current.playerAnimator.SetBool("Defeat", true);
                LevelController.Current.GameOver();
            }

        }

        if (other.tag == "End" && dressValue <= 100)
        {

            if (dressValue < 100)
            {
                dressValue += 10;
            }
            if (dressValue == 100)
            {

                PlayerController.Current.playerAnimator.SetBool("Running", false);
                PlayerController.Current.playerAnimator.SetBool("Dancing", true);

                LevelController.Current.score *= scoreX;
                LevelController.Current.FinishMenu();
                //evelController.Current.gameActive = false;
            }

            bodySkinnedMeshRenderer.SetBlendShapeWeight(0, dressValue);


            Debug.Log(dressValue);
        }


    }
   /* public IEnumerator MoveOverSeconds(GameObject objectToMove, Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = objectToMove.transform.position;
        while (elapsedTime < seconds)
        {
            objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        objectToMove.transform.position = end;
    }*/


}
