using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleModificator : MonoBehaviour
{
    [SerializeField] Vector3 velocidadRotacion;
    [SerializeField] List<Transform> rectanglesList = new List<Transform>();
    //int initIF;
    float tamañoMax = 1.5f;
    Vector3 tamañoDefault = new Vector3(0.8f, 0.29f, 0.8f);
    Vector3 vectorPrueba = new Vector3(1f, 1f, 1f);
    float seconds;
    public Vector3 vectorEscalado;
    float durationSeconds = 0.2f;
    float timeBeetweenSpawns = 0.3f;
    float timeBeetweenScaleChange = 5f;
    bool isChange = false;
    [SerializeField] AnimationCurve ease;
    Vector3 tamaño;
    //WhilesForFusion WFF = new WhilesForFusion();
    Coroutine courtinas = null;
    float segundosDeAnim;
    float comienzaOtraVez = 100f;
    void Start()
    {
       StartCoroutine(RotaAndaVersionLoreAcurate());
        //StartCoroutine(scaleChanger());
        //StartCoroutine(SeRepiteOtraVez());
        //WFF.BipBopSingleAnimatio();
        //StartCoroutine(PopApop());
        //StartCoroutine(ScaleChToNrScale());
        //StartCoroutine(BipBopSingleAnimatio());
    }

    void Update()
    {
        print(segundosDeAnim);
       
    }

    public IEnumerator scaleChanger()
    {
        
        
            //WFF.initIF = 0;
            seconds = 0;
            vectorEscalado = new Vector3(tamañoMax, tamañoMax, tamañoMax);
            //isChange = false;

            while (seconds < durationSeconds)
            {

                seconds += Time.deltaTime;
                segundosDeAnim ++;
                //WFF.initIF++;
                //WFF.rectanglesList.Add(transform);

                //float scaleX = Mathf.Lerp(
                //    tamañoDefault.x, 
                //    tamañoMax, 
                //    ease.Evaluate(seconds/durationSeconds));

                //float scaleY = Mathf.Lerp(
                //     tamañoDefault.x,
                //     tamañoMax,
                //     ease.Evaluate(seconds / durationSeconds));


                //yield return new WaitForSeconds(timeBeetweenScaleChange);
            
            
            
                    //transform.localScale = Vector3.Lerp(
                    //    vectorPrueba, 
                    //    vectorEscalado, 
                    //    ease.Evaluate(seconds/durationSeconds));
                    //yield return new WaitForSeconds(timeBeetweenSpawns);
                    transform.localScale = Vector3.Lerp(
                        vectorPrueba,
                        vectorEscalado,
                        ease.Evaluate(seconds / durationSeconds));
                    yield return new WaitForEndOfFrame();

                //transform.localScale = Vector3.Lerp(
                //    tamañoMax, 
                //    tamañoDefault, 
                //    seconds / durationSeconds);
                //    yield return new WaitForSeconds(timeBeetweenSpawns);
                //transform.localScale = vectorPrueba;
                //yield return new WaitForSeconds(timeBeetweenSpawns);
            }
        transform.localScale = vectorPrueba;
        yield return new WaitForSeconds(timeBeetweenSpawns);
    }
    //yield return null;

    //public IEnumerator colors()
    //{
    //    while (true)
    //    {
            
    //        Material.color = new Color(
    //            Normalize(cordinates.x, -10, 10),
    //            Normalize(cordinates.y, -10, 10),
    //            Normalize(cordinates.z, -10, 10)
    //        );
    //        yield return null;
    //        float Normalize(float valor, float min, float max)
    //        {
    //            return (valor - min) / (max - min);
    //        }
    //    }
    //}

    public void AnimacionPop()
    {
        StartCoroutine(scaleChanger());
    }
    //public IEnumerator BipBopSingleAnimatio()
    //{
    //    int a = 0;

    //    while (WFF.rectanglesList.Count == 0)
    //        yield return null;

    //    while (true)
    //    {
    //        WFF.rectanglesList[a].StartCoroutine(scaleChanger());
    //        a = ++a % WFF.rectanglesList.Count;
    //        print("a");
    //        yield return new WaitForSeconds(WFF.timeBetweenSpawns);
    //    }
    //}

    //public IEnumerator SeRepiteOtraVez()
    //{
    //    while (true)
    //    {
    //        while(segundosDeAnim < comienzaOtraVez)
    //        {
    //            StartCoroutine(scaleChanger());
    //            yield return null;
    //        }
    //    }
    //}
    public IEnumerator ScaleChToNrScale()
    {
        seconds = 0;
        while (seconds < durationSeconds)
        {
            seconds += Time.deltaTime;
            transform.localScale = vectorPrueba;
            yield return null;
        }
        courtinas = null;
    }

    public IEnumerator PopApop()
    {
        while (true)
        {
            StartCoroutine(scaleChanger());
            while(courtinas != null)
                yield return null;


            StartCoroutine(ScaleChToNrScale());
            while(courtinas != null)
                yield return null;
        }
    }

    
    public IEnumerator RotaAndaVersionLoreAcurate()
    {
        while (true)
        {
            transform.Rotate(velocidadRotacion * Time.deltaTime);
            yield return null;
        }
    }
}
