using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    float length;
    float startPos;

    public GameObject mainCam;

    public float parallaxAmt;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = mainCam.transform.position.x * (1 - parallaxAmt);

        float dist = (mainCam.transform.position.x * parallaxAmt);
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if(temp > startPos + length)
        {
            startPos += length;
        } else if(temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
