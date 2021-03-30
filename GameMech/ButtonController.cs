using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer theSR;
	public Sprite defaultImage;
	public Sprite pressedImage;
	
	public KeyCode keyToPress;
    public AudioSource hitSound;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)){
			theSR.sprite = pressedImage;
            if (GameManager.instance.startPlaying) {
                hitSound.Play();
            }
		}
		
		if(Input.GetKeyUp(keyToPress)){
			theSR.sprite = defaultImage;
		}
    }
}
