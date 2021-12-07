using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    Rigidbody2D myBody;

    bool onFloor = true;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= speed * Time.deltaTime;
        } else if (Input.GetKey(KeyCode.D))
        {
            newPos.x += speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.W) && onFloor)
        {
            myBody.AddForce(Vector2.up * jumpForce);
            onFloor = false;
        }

        transform.position = newPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }
    }

}
