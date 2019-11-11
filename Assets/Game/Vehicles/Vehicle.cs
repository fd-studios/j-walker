using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    public float Speed = 6;

    float initialX;

    // Start is called before the first frame update
    void Start()
    {
        initialX = transform.position.x;
        if (initialX > 0)
            Speed *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Speed * Time.deltaTime, 0f, 0f);

        if (Mathf.Abs(transform.position.x) > 12)
            transform.position = new Vector2(initialX, transform.position.y);

    }
}
