using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleOrb : MonoBehaviour
{

    [SerializeField] private OrbGenerater OrbGenerater = null;





    public void ShuffleButtonClick()
    {
        foreach (var orb in OrbGenerater.OrbList)
        {
            orb.GetComponent<OrbController>().ShuffleAction();
        }
    }
}