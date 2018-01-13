using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Ball : MonoBehaviour {
    public float speed = 150;

    private Rigidbody2D rigidBody;
    public Text leftcontent;
    public Text rightcontent;
    int leftcount;
    int rightcount;

    // Use this for initialization
    void Start () {
       // leftcontent.text = leftcount.ToString();
        //rightcontent.text = rightcount.ToString();
        rigidBody = GetComponent<Rigidbody2D>();
        leftcount = 0;
        rightcount = 0;
       
        stext();
        int num = Random.Range(0, 2);
        if (num == 0) {
            rigidBody.velocity = Vector2.right * speed;
         
        }
        else { rigidBody.velocity = Vector2.left * speed; }
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.name == "Leftpaddle") || (collision.gameObject.name == "Rightpaddle"))
        {
            float rebound = ((transform.position.y - collision.transform.position.y) / collision.collider.bounds.size.y);
            Vector2 dir = new Vector2();
            if (collision.gameObject.name == "Leftpaddle")
            {

                dir = new Vector2(1, rebound).normalized;

            }

            if (collision.gameObject.name == "Rightpaddle")
            {

                dir = new Vector2(-1, rebound).normalized;


            }

            rigidBody.velocity = dir * speed;
        }
        if (collision.gameObject.name == "Leftwall") {
            rightcount = rightcount + 1;
            rightcontent.text = rightcount.ToString();
            transform.position = new Vector2(0, 0);
          
           

        }
        if  (collision.gameObject.name == "Rightwall") {
            leftcount = leftcount + 1;
            leftcontent.text = leftcount.ToString();
            transform.position = new Vector2(0, 0);
           
            

        }



    }
    // Update is called once per frame
    void stext () {
        leftcontent.text = leftcount.ToString();
        rightcontent.text = rightcount.ToString();
    }
}
