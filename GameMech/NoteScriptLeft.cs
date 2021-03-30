using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;

public class NoteScriptLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public float tempo;
    public bool hasStarted;

    public float speed;
    public static NoteScript instance;


    void Start()
    {
        speed = tempo / 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted) {
            transform.position += new Vector3((speed / (float) 2.0 * (float) Math.Sqrt(3)) * Time.deltaTime, -(speed / (float) 2.0) * Time.deltaTime, 0f);
        }
    }
}
// / (float)Math.Sqrt(3)
// * (float) Math.Sqrt(3)