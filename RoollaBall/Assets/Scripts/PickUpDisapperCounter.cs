using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDisapperCounter : MonoBehaviour
{
    public int DissapperCount { get;private set; } = 0;

    [SerializeField] private ColliderReceiveAction colliderReceiveAction = null;

    private void Update()
    {
        if (colliderReceiveAction == null)
        {
            return;
        }

        if(colliderReceiveAction.IsTriggerEnter)
        {
            DissapperCount++;
            PickUpCountPresenter.CountDisplay(DissapperCount);
        }
    }

}
