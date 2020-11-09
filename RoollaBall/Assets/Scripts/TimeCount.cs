using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCount : MonoBehaviour


{

    public float TimeUpdateCounts { get; private set; } = 10f;
    // Start is called before the first frame update
 

    // Update is called once per frame
   public virtual void Update()
    {
        TimeUpdateCounts -= Time.deltaTime;

        
    }
}
