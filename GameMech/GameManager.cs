using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

/*
Bug 1: Score don't display after 1 million
*/
public class GameManager : MonoBehaviour
{
    // Overall Managements
    public AudioSource music; 
    public bool startPlaying;
    public NoteScript tNoteScript;
    public NoteScriptLeft tNoteScriptLeft;
    public NoteScriptRight tNoteScriptRight;

    // Data
    public float accuracy;
    public int combo;
    // Scores
    public float score;
    public float scorePerNote, scorePerNoteGood,scorePerNoteBad;
    public float comboBonus;


    // Number of Notes
    public int numOfNotes;

    // Finish the game or just as a tool to gauage the song finish
    public int totalNotesPlayed;
    public int numOfNotesPerfect, numOfNotesGood, numOfNotesBad, numOfNotesMissed;
    // All Text Information
    public Text comboText;
    public Text scoreText;
    public float tempo;
    // For Mods
    public float multiplier;
    public static GameManager instance;
    // Start is called before the first frame update



    // Result Scree
    public GameObject resultScreen;
    public Text textPerfect, textGood, textBad, textMissed;
    public Text textAccuracy, textRank, textTotal, textFinalCombo, textFinalScore;
    void Start()
    {
        instance = this;
        // Reseting Combo
        combo = 0;

        // Calculating for the level
        comboBonus = (float) Math.Floor(150000.0 / triangle(numOfNotes));
        scorePerNote = (float) Math.Floor(850000.0 / numOfNotes);
        scorePerNoteGood = (float) Math.Floor(0.8 * scorePerNote);
        scorePerNoteBad = (float) Math.Floor(0.5 * scorePerNote);
        numOfNotes = GameObject.FindObjectsOfType(typeof(NoteCod)).Length;

    }

    // Update is called once per frame
    void Update()
    {
        totalNotesPlayed = numOfNotesPerfect + numOfNotesGood + numOfNotesBad + numOfNotesMissed;
        if (!startPlaying) {
            if (Input.anyKeyDown) {
                
                startPlaying = true;
                music.Play();
                tNoteScript.hasStarted = true;
                tNoteScriptLeft.hasStarted = true;
                tNoteScriptRight.hasStarted = true;
                
                Debug.Log("Game Start!!!");
            }
        }

        if (totalNotesPlayed == numOfNotes) {
            music.Stop();
            // Show results
            // Million Master
            if (numOfNotesPerfect == numOfNotes) {
                scoreText.text = "Score: 1000000";
            }
        }
    }

    public void Note() {
        scoreText.text = "Score: " + score;
        comboText.text = "" + combo;
    }
    public void NotePerfect() {
        combo += 1;
        score += scorePerNote + (combo * comboBonus);
        numOfNotesPerfect += 1;
        Debug.Log("Perfect");
        Note();
    }

    public void NoteGood() {
        combo += 1;
        score += scorePerNoteGood + (combo * comboBonus);
        numOfNotesGood += 1;
        Debug.Log("Good");
        Note();
    }

    public void NoteBad() {
        combo = 0;
        score += scorePerNoteBad + (combo * comboBonus);
        numOfNotesBad += 1;
        Debug.Log("Bad");
        Note();
    }
    public void NoteMiss() {
        combo = 0;
        score += 0;
        numOfNotesMissed += 1;
        Debug.Log("Missed");
        Note();
    }

    public void pause() {

    }

    // Helper Functions
    private int triangle(int n) {
        if (n == 0) {
            return 0;
        } else {
            return n + triangle(n - 1);   
        }
    }
}
