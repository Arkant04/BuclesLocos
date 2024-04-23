using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionObjeto : MonoBehaviour
{
    [Header("Velocidad de rotacion")]
    [SerializeField] float MaxXRotationSpeed;
    [SerializeField] float MaxYRotationSpeed;
    [SerializeField] float MaxZRotationSpeed;
    float MinXRotationSpeed = 4f;
    float MinYRotationSpeed;
    float MinZRotationSpeed;
    Vector3 A;

    [Header("Duracion de animacion")]
    [SerializeField] float XAnimationDuration;
    [SerializeField] float YAnimationDuration;
    [SerializeField] float ZAnimationDuration;
    [SerializeField] AnimationCurve Ease;
    float secondsX;
    float secondsY;
    float secondsZ;
    float durationSeconds = 15f;


    void Start()
    {
        StartCoroutine(RotacionX());
        StartCoroutine(RotacionY());
        StartCoroutine(RotacionZ());
    }

    void Update()
    {
       //Vector3 rotation = new Vector3(MaxXRotationSpeed, MaxYRotationSpeed, MaxZRotationSpeed);
       // transform.Rotate(rotation * Time.deltaTime);    
    }


    public IEnumerator RotacionX()
    {
        while (true)
        {

            while (secondsX < XAnimationDuration)
            {
                secondsX += Time.deltaTime;
                float I = Mathf.Lerp(MaxXRotationSpeed, -MaxXRotationSpeed, Ease.Evaluate(secondsX/XAnimationDuration));
                //Vector3 B = new Vector3(MinXRotationSpeed, 0, 0);
                //Debug.Log(B);
                //transform.rotation = Quaternion.Lerp(A, B, Ease.Evaluate(MaxXRotationSpeed/XAnimationDuration));

                Vector3 A = new Vector3(I, 0, 0);
                //if (Ease.Evaluate(XAnimationDuration / -XAnimationDuration) == 0)
                    transform.Rotate(A * Time.deltaTime);
               
                yield return new WaitForEndOfFrame();
                //Debug.Log(A);
                //print(Ease.Evaluate(seconds / XAnimationDuration));
                //yield return new WaitForSeconds(Ease.Evaluate(XAnimationDuration));
                //transform.Rotate(B * Time.deltaTime);
                //yield return new WaitForSeconds(Ease.Evaluate(XAnimationDuration));
            }
            //transform.Rotate(A * Time.deltaTime);
            secondsX = 0;
            yield return null;
        }
    }

    public IEnumerator RotacionY()
    {
        while (true)
        {

            while (secondsY < YAnimationDuration)
            {
                secondsY += Time.deltaTime;
                float J = Mathf.Lerp(MaxYRotationSpeed, -MaxYRotationSpeed, Ease.Evaluate(secondsY / YAnimationDuration));
                //Vector3 B = new Vector3(MinXRotationSpeed, 0, 0);
                //Debug.Log(B);
                //transform.rotation = Quaternion.Lerp(A, B, Ease.Evaluate(MaxXRotationSpeed/XAnimationDuration));

                Vector3 A = new Vector3(0, J, 0);
                //if (Ease.Evaluate(XAnimationDuration / -XAnimationDuration) == 0)
                transform.Rotate(A * Time.deltaTime);

                yield return new WaitForEndOfFrame();
                //Debug.Log(A);
                //print(Ease.Evaluate(seconds / durationSeconds));
                //yield return new WaitForSeconds(Ease.Evaluate(XAnimationDuration));
                //transform.Rotate(B * Time.deltaTime);
                //yield return new WaitForSeconds(Ease.Evaluate(XAnimationDuration));
            }
            //transform.Rotate(A * Time.deltaTime);
            secondsY = 0;
            yield return null;
        }
    }

    public IEnumerator RotacionZ()
    {
        while (true)
        {

            while (secondsZ < ZAnimationDuration)
            {
                secondsZ += Time.deltaTime;
                float K = Mathf.Lerp(MaxZRotationSpeed, -MaxZRotationSpeed, Ease.Evaluate(secondsZ / ZAnimationDuration));
                //Vector3 B = new Vector3(MinXRotationSpeed, 0, 0);
                //Debug.Log(B);
                //transform.rotation = Quaternion.Lerp(A, B, Ease.Evaluate(MaxXRotationSpeed/XAnimationDuration));

                Vector3 A = new Vector3(0, 0, K);
                //if (Ease.Evaluate(XAnimationDuration / -XAnimationDuration) == 0)
                transform.Rotate(A * Time.deltaTime);

                yield return new WaitForEndOfFrame();
                //Debug.Log(A);
                //print(Ease.Evaluate(seconds / durationSeconds));
                //yield return new WaitForSeconds(Ease.Evaluate(XAnimationDuration));
                //transform.Rotate(B * Time.deltaTime);
                //yield return new WaitForSeconds(Ease.Evaluate(XAnimationDuration));
            }
            //transform.Rotate(A * Time.deltaTime);
            secondsZ = 0;
            yield return null;
        }
    }
}
