using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAutoPleacement : MonoBehaviour
{
    [SerializeField] private GameObject PickUp;
    [SerializeField] private float radius = 5f;

    public Transform[] PickupTransforms = null;


    // Start is called before the first frame update
  private   void Start()
    {
        var pos = Vector3.zero;

        Vector3 defPos = GetComponent<Transform>().position;
        var radian = Mathf.PI * 2 / 10;
        pos.z += radius;
        PickupTransforms = new Transform[12];
        for (int i = 0;i< 10;i++)
        {
            var pickUp = Instantiate(PickUp);
            pos.z = Mathf.Cos(radian * i) * radius + defPos.z;
            pos.x = Mathf.Sin(radian * i) * radius + defPos.x;
            pos.y = defPos.y;
            pickUp.transform.position = pos;

            PickupTransforms[i] = pickUp.transform;
        }


        }
    }



