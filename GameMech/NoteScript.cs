using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NoteScript : MonoBehaviour
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
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }
    }
}
