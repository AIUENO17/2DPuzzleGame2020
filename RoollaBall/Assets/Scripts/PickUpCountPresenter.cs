using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpCountPresenter : MonoBehaviour
{
    [SerializeField] private Text pickUpCountText = null;

    private static int pickUpCounter = 0;
    // Start is called before the first frame update
    

    // Update is called once per frame

    public int GetPickUpCount
    {
        get { return pickUpCounter; }
    }
   public  void Update()
    {
        pickUpCountText.text = $"{pickUpCounter}";
    }
    /// <summary>
    /// <param name="dissapperCount"></param>
   
    public static void CountDisplay(int dissapperCount)
    {
        pickUpCounter += dissapperCount;
    }
}
