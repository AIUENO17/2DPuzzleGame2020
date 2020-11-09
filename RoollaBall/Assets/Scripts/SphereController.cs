using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float speed = 10.0f;

    public Rigidbody uy;
    void Start()
    {
        uy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;

        float z = Input.GetAxis("Vertical") * speed;
        uy.AddForce(x, 0, z);
    }
}
