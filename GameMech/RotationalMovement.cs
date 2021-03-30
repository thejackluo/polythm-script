// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class RotationMovement : MonoBehaviour
// {
// 	public Rigidbody2D rb; 
// 	public Camera cam;
// 	Vector2 mousePos;
	
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
// 	}
	
// 	void FixedUpdate(){
// 		Vector2 direction = mousePos - rb.position;
// 		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
// 		rb.rotation = angle;
// 		Vector2 position = new Vector2(Mathf.Cos(angle) * 2, Mathf.Sin(angle)) * 2;
// 		rb.MovePosition(position);
// 	}
// }
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{
	public Rigidbody2D rb; 
	public Camera cam;
	Vector2 mousePos;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		FixedUpdate();
	}
	
	void FixedUpdate(){
		// Vector2 direction = mousePos - rb.position;
		// float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
		transform.Rotate(0f, 0f, 60*Time.deltaTime, Space.Self);
		// Vector2 position = new Vector2(Mathf.Cos(angle) * 2, Mathf.Sin(angle)) * 2;
		// transform.MovePosition(position);
	}
}
