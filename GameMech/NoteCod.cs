using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCod : MonoBehaviour
{
    public bool canBePressed;
    public bool Pressed;

    public KeyCode keyToPress;
    public int hitBoxNum;

    public float perfectHit;
    public float goodHit;

    // New Information
    // public int measure;
    // public int division;
    // public int lane;
    // public float bpm;

    // // Game Information
    // public float songDelay;
    // public float angle;
    // public float distance;
    // public float xPos;
    // public float yPos;
    // // Units per second
    // public float speed;

    // Start is called before the first frame update
    void Start()
    {
        perfectHit = (float)0.4;
        goodHit = (float)0.8;
        Pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress)) {
            if (canBePressed) {
                Pressed = true;

                if (hitBoxNum == 1) {
                    if (distance(0, -2) < perfectHit) {
                        GameManager.instance.NotePerfect();
                    } else if (distance(0, -2) < goodHit) {
                        GameManager.instance.NoteGood();
                    } else {
                        GameManager.instance.NoteBad();
                    }
                } else if (hitBoxNum == 0) {
                    if (distance((float)-1.64, (float)0.4) < perfectHit) {
                        GameManager.instance.NotePerfect();
                    } else if (distance((float)-1.64, (float)0.4) < goodHit) {
                        GameManager.instance.NoteGood();
                    } else {
                        GameManager.instance.NoteBad();
                    }

                } else if (hitBoxNum == 2) {
                    if (distance((float)1.64, (float)0.4) < perfectHit) {
                        GameManager.instance.NotePerfect();
                    } else if (distance((float)1.64, (float)0.4) < goodHit) {
                        GameManager.instance.NoteGood();
                    } else {
                        GameManager.instance.NoteBad();
                    }
                }
               

                gameObject.SetActive(false);
                Destroy(this.gameObject);
                
            }
        }
    }

    private float distance(float x, float y) {
        return Mathf.Sqrt(Mathf.Pow(transform.position.x - x , 2) + Mathf.Pow(transform.position.y - y , 2));
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Activator"){
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.tag == "Activator"){
            canBePressed = false;
            // Check what this is
            Invoke("NoteMissTrigger", (60 / GameManager.instance.tempo));
        }
    }

    private void NoteMissTrigger() {
        if (!Pressed) {
            GameManager.instance.NoteMiss();
        }
        gameObject.SetActive(false);
        Destroy(this.gameObject);
    }

    // When user resets the game 
    private void reset() {
        gameObject.SetActive(true);
    }
}
