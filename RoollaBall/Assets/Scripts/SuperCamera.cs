using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCamera : MonoBehaviour
{

    private GameObject player;
    private Vector3 offset;


     void Start()
    {
        this.player = GameObject.Find("Sphere");

        offset = transform.position - player.transform.position;
        
    }


    // Update is called once per frame
    void Update()
    {

        transform.position = player.transform.position + offset;


        }

    }

        
    
