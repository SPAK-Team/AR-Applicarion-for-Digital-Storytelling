using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARSessionCustom : MonoBehaviour
{

    private ARSession arSession;
    void Start()
    {
        arSession = GetComponent<ARSession>();
        arSession.Reset();

    }

   
}
