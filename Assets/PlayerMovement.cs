using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3;
     float y;
     float x;
    private Rigidbody2D rb;
    float bottomLimit;
    float leftLimit;
    float TopLimit;
    float rigthLimit;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
         bottomLimit = bottomLeft.y;
         leftLimit = bottomLeft.x;

        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
         TopLimit = topRight.y;
         rigthLimit = topRight.x;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.position += new Vector3(x, y, 0f) * speed * Time.deltaTime;
        //rb.MovePosition(transform.position + new Vector3(x, y, 0f) * speed * Time.deltaTime);
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        Vector3 desiredPosition = transform.position + new Vector3(x, y, 0f) * speed * Time.fixedDeltaTime;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftLimit, rigthLimit);

        desiredPosition.y = Mathf.Clamp(desiredPosition.y, bottomLimit, TopLimit);

        rb.MovePosition(desiredPosition);

        
    }
}

