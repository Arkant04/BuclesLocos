using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BuclesWhile : MonoBehaviour
{
    [SerializeField] int durationFrames;
    [SerializeField] float fromFloat;
    [SerializeField] float toFloat;
    [SerializeField] AnimationCurve animacionCurva;
    [SerializeField] Vector3 rotation;
    int startFrames;
    float seconds;
    Vector3 cordenah;
    //[SerializeField] Transform punto1;
   // [SerializeField] Transform punto2;
    int startPoint;
    int toPoint;
    [SerializeField] List<Transform> listaPositions = new List<Transform>();
    [SerializeField] List<Color> listaColores = new List<Color>();
    [SerializeField] bool rotate;
    //[SerializeField] GameObject cubeGobj;
    [SerializeField] Transform ObjetcToMove;
    [SerializeField] float durationSeconds;

    void Start()
    {
        startPoint = 0;
        toPoint = 1;
        ObjetcToMove.transform.position = listaPositions[0].position;
        //StartCoroutine(printA());
        StartCoroutine(printSecondo());
       // StartCoroutine(RotaAnda());
    }

    public IEnumerator printA()
    {
        while(startFrames <= durationFrames)
        {
            startFrames++;
            print(startFrames);
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator printSecondo()
    {
        while (true)
        {
            while (seconds <= durationSeconds)
            {
                //if ((startPoint > 1 && toPoint > 2) || (startPoint == 0 && toPoint == 0))
                //{
                //    startPoint = 2;
                //    toPoint = 0;
                          
                //}

                //if(startPoint >= 3 && toPoint >= 1)
                //{
                //    startPoint = 0;
                //    toPoint = 1;
                //}
                seconds += Time.deltaTime;
                //ObjetcToMove.transform.position = new Vector3 (seconds, 0, 0); 
                /*ObjetcToMove.transform.position =  new Vector3( Normalize(fromFloat, toFloat, seconds),
                    Normalize(fromFloat, toFloat, seconds),
                    0);*/

                ////Mueve el objeto/////
                ObjetcToMove.transform.position = Vector3.Lerp(
                    listaPositions[startPoint].position, 
                    listaPositions[toPoint].position, 
                    animacionCurva.Evaluate(seconds/durationSeconds));

                /////Colorea////
                ObjetcToMove.GetComponent<MeshRenderer>().material.color = Color.Lerp(
                    listaColores[startPoint], 
                    listaColores[toPoint], 
                    animacionCurva.Evaluate(seconds/durationSeconds));

                ////Rota////
                ObjetcToMove.transform.rotation = Quaternion.Slerp(
                    listaPositions[startPoint].rotation, 
                    listaPositions[toPoint].rotation, 
                    animacionCurva.Evaluate(seconds/durationSeconds));
                //print("a " + seconds);
                //float Normalize(float valor, float min, float max)
                //{
                //    return (valor - min) / (max - min);
                //}
                yield return new WaitForEndOfFrame();
            }
            seconds = 0;
            //startPoint += 1;
            //toPoint += 1;
            //print("going from " + startPoint + " to " + toPoint);
            yield return null;
            indexChanger();
        }
    }

    public IEnumerator RotaAnda()
    {
        while (true)
        {
            if (rotate == true)
                ObjetcToMove.transform.Rotate(rotation * Time.deltaTime);
            yield return null;
        }
    }
    void indexChanger()
    {
        startPoint = toPoint;
        toPoint = (startPoint + 1) % listaPositions.Count;
    }
}
