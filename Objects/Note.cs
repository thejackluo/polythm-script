using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Note", menuName = "Note")]
public class Note : ScriptableObject
{
    // Important Information
    public int measure;
    public int division;
    public int lane;
    public float bpm;

    // Game Information
    public float songDelay;
    public float angle;
    public float distance;
    public float xPos;
    public float yPos;
    // Units per second
    public float speed;

    
    // Different Hit Sounds
    
    // Start is called before the first frame update
    void Start()
    {
        speed = bpm / 60;
        angle = (360 / division) / (180 / Mathf.PI);
        distance = 4 * measure + songDelay * speed;
        calculatePos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void calculatePos() {
        xPos = distance * Mathf.Cos(angle);
        yPos = distance * Mathf.Sin(angle);
    }
}