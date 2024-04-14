using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bucleA : MonoBehaviour
{
    [SerializeField] int cantidad;
    [SerializeField] GameObject spherePf;
    [SerializeField] bool rotate;
    [SerializeField]List<GameObject> listaCirculo;
    int numeroObj = 0;
    Vector3 cordenadas;
    string nombre = "Pepito";
    Coroutine courtinas = null;
    [SerializeField] Vector3 rotation;
    [SerializeField] int start;
    [SerializeField] float timeBeetweenPrints;
    void Start()
    {
        //for (int i = 0; i < as; i++)
        //{
        //    //cordenadas.x += 1;
        //    //cordenadas.y += 2;
        //    //cordenadas.z -= 3;
        //    cordenadas = new vector3(i, 2 * i, -3 * i);
        //    print(cordenadas);
        //}
        listaCirculo = new List<GameObject>();
        StartCoroutine(destroyAndSpawn());
        StartCoroutine(RotaAnda());
    }

  

    public IEnumerator destroyAndSpawn()
    {
        while (true)
        {
           courtinas = StartCoroutine(cordenahCourutine());
            while(courtinas != null)
                yield return null;

            courtinas = StartCoroutine(destroyCircle());
            while(courtinas != null) 
                yield return null;
        }
    }

    IEnumerator cordenahCourutine()
    {
        for (int i = start; i < start + cantidad  ; i++)
            for (int j = start; j < start + cantidad; j++)
                for (int k = start; k < start + cantidad; k++)
                {
                    if ((i == start && j == start) 
                        || 
                        (j == start && k == start) 
                        ||
                        (i == start && k == start)
                        ||
                        (i == start + cantidad -1 && j == start + cantidad - 1) 
                        || 
                        (j == start + cantidad -1 && k == start + cantidad -1)
                        ||
                        (i == start + cantidad - 1 && k == start + cantidad - 1) 
                        ||
                        (i == start && j == start + cantidad -1)
                        ||
                        (j == start && k == start + cantidad -1)
                        ||
                        (k == start && i == start + cantidad -1)
                        ||
                        (i == start + cantidad -1 && j == start)
                        ||
                        (j == start + cantidad -1 && k == start)
                        ||
                        (k == start + cantidad -1 && i == start)
                        )
                    {
                        cordenadas = new Vector3(j, i, k);
                        numeroObj++;
                        instaciatePrefab(spherePf);
                        yield return new WaitForSeconds(timeBeetweenPrints);
                    }
                
                
                }
        courtinas = null;
        //StartCoroutine(destroyPF(spherePf));

    }

    public IEnumerator RotaAnda()
    {
        while (true)
        {
            if(rotate == true)
            transform.Rotate(rotation*Time.deltaTime);
            yield return null;
        }
    }


   
    public IEnumerator destroyCircle()
    {
        while (listaCirculo.Count > 0)
        {
            Destroy(listaCirculo[0]);
            listaCirculo.RemoveAt(0);
            yield return new WaitForSeconds(timeBeetweenPrints);
        }
        courtinas = null;
    }

    public void instaciatePrefab(GameObject esferaGM)
    {

        GameObject AS = Instantiate(
            esferaGM, 
            transform);
        AS.transform.localPosition = cordenadas;
        esferaGM.name = nombre;
        esferaGM.name += numeroObj;
        listaCirculo.Add(AS);
        AS.GetComponent<MeshRenderer>().material.color = new Color(
            Normalize(cordenadas.x, -10, 10),
            Normalize(cordenadas.y, -10, 10),
            Normalize(cordenadas.z, -10, 10)
        );
        float Normalize(float valor, float min, float max)
        {
            return (valor - min) / (max - min);
        }
        listaCirculo.Add(AS);
        print("He instanciado la esfera"+ " "+esferaGM.name + " " +"en las cordenadas"+ " " + cordenadas);
    }
}
        //for(int i = 0; i < listaCirculo.Count; i++)
        //{
        //    listaCirculo.Remove(spherePf);
        //    yield return null;
        //}
