using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleMove : MonoBehaviour {
    public float speed = 30;

	void Update () {
        float movement = Input.GetAxisRaw("Vertical");//input w=up,s = down
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, movement) * speed;
	}
}
