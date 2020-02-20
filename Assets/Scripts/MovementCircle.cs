using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCircle : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = Vector2.up * speed;

        if (player == null)
        {
            rb.velocity = Vector3.zero;
            Time.timeScale = 0.1f;
        }
    }

}
