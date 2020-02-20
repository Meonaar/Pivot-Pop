using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform rotationPoint;
    private SpriteRenderer sr;

    public float radius;
    public float speed;
    public GameObject destroyEffect;

    float posX, posY;
    float angle;
    int startScrore = 0;

    [HideInInspector]
    public float score;


    bool clicked;
    float a = 1;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        score = startScrore;
    }
    // Update is called once per frame
    void Update()
    {
        posX = rotationPoint.position.x + Mathf.Cos(angle) * radius;
        posY = rotationPoint.position.y + Mathf.Sin(angle) * radius;

        if (Input.GetMouseButtonDown(0) && !clicked)
        {
            a = -1;
            clicked = true;            
        }
        else if (Input.GetMouseButtonDown(0) && clicked)
        {
            a = 1;
            clicked = false;
        }

        angle += a * Time.deltaTime * speed;
        transform.position = new Vector2(posX, posY);
        if (angle >= 360)
        {
            angle = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            string tagName = collision.gameObject.tag;
            sr.color = collision.GetComponent<SpriteRenderer>().color;
        }
        else
        {
            if (sr.color != collision.GetComponent<SpriteRenderer>().color)
            {
                Destroy(this.gameObject);
                
            }
            else
            {
                GameObject expl = Instantiate(destroyEffect, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                score++;
            }
        }

    }
}
