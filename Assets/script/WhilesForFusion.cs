using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhilesForFusion : MonoBehaviour
{
    [SerializeField] int start;
    [SerializeField] public int amount;
    [SerializeField] Vector3 velocidadRotacion;
    //[SerializeField] Transform rectangleTF;
    public int initIF;
    bool rota = true;
    Vector3 cordinates;
    [SerializeField] public float timeBetweenSpawns;
    [SerializeField] GameObject rectanglePF;
    [SerializeField] public List<ScaleModificator> rectanglesList = new List<ScaleModificator>();
    //[SerializeField] Transform MainManagerTR;
    [SerializeField] float TimeBetweenboom;
    
    //ScaleModificator SM;


    void Start()
    {
        Camera.main.transform.position = new Vector3(
            (amount - 1) * 0.35f,
            (amount - 1) * 0.55f,
            -(amount - 1) * 0.5f
        );
        Camera.main.transform.LookAt(new Vector3(
            (amount - 1) * 0.5f,
            0,
            (amount - 1) * 0.5f
        ));
        //SM = rectanglePF.GetComponent<ScaleModificator>();
        StartCoroutine(SpawnObj());
        StartCoroutine(animarioPOP());
        StartCoroutine(animarioPOPTocho());
        //StartCoroutine(BipBopSingleAnimatio());
        //StartCoroutine(RotaAndaVersionLoreAcurate());
    }

    void Update()
    {
        
    }

    public IEnumerator SpawnObj()
    {
        ScaleModificator SM;
        for (int i = 0; i <= amount; i++)
            for(int j = 0; j <= amount; j++)
            {
                SM = Instantiate(rectanglePF,
                    cordinates = new Vector3(i, 0, j),
                    Quaternion.identity).GetComponent<ScaleModificator>();
                //cordinates = new Vector3(i, 0, j);
                
                rectanglesList.Add(SM);
                //rectanglePF.transform.localScale = new Vector3( +1, 0, 0);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }
       // StartCoroutine(colors());
        // SM.PopApop();

    }


    //public IEnumerator colors()
    //{
    //    while (true)
    //    {
    //        rectanglePF.GetComponent<MeshRenderer>().material.color = new Color(
    //            Normalize(cordinates.x, -10, 10),
    //            Normalize(cordinates.y, -10, 10),
    //            Normalize(cordinates.z, -10, 10)
    //        );
    //        yield return null;
    //    }
    //}

        float Normalize(float valor, float min, float max)
        {
            return (valor - min) / (max - min);
        }

    public IEnumerator animarioPOP()
    {
        int a = 0;
        while (rectanglesList.Count < 0)
        {
            yield return null;
        }

        while (true)
        {
            rectanglesList[a].AnimacionPop();
            //rectanglesList[a].RotaAndaVersionLoreAcurate();
            a++;
            print("a");
            if(a >= rectanglesList.Count)
            {
                a = 0;
            }
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    public IEnumerator animarioPOPTocho()
    {

        while (true)
        {
            for(int i = 0; i < rectanglesList.Count; i++)
            {
                rectanglesList[i].AnimacionPop();
                yield return null;
            }
           
            yield return new WaitForSeconds(TimeBetweenboom);
        }
    }

    //public IEnumerator RotaAndaVersionLoreAcurate()
    //{
    //    while (true)
    //    {
    //        rectanglesList[start].transform.Rotate(velocidadRotacion * Time.deltaTime);
    //        print("a");
    //        yield return null;
    //    }
    //}

    //public IEnumerator RotaAndaVersionLoreAcurate()
    //{
    //    while (true)
    //    {
    //        rectanglePF.transform.Rotate(velocidadRotacion * Time.deltaTime);
    //        yield return null;
    //    }
    //}

    //public void instanciatePrefab(GameObject rectanclePf)
    //{
    //    GameObject rectangle = Instantiate(
    //        rectanclePf,
    //        cordinates, Quaternion.identity);

    //    if(SM == null)
    //    {
    //        SM = rectangle.AddComponent<ScaleModificator>();
    //    }

    //    rectanglesList.Add(SM);
    //    //rectanclePf.transform.position = cordinates;
    //}
}
