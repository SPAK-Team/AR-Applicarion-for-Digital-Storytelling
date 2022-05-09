using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovetoTarget : MonoBehaviour
{
    public Transform target;
    public float t;
    public float speed;

    void FixedUpdate()
    {
        //Set mousePosition
        //transform.position = target.position;

        Vector3 a = transform.position;
        Vector3 b = target.position;

        //Lerp
        //transform.position = Vector3.Lerp(a, b, t);
        //Move toward
        transform.position = Vector3.MoveTowards(a, b, speed);

    }
}
