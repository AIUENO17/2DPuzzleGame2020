using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class ComboCounter : MonoBehaviour
{
    public List<GameObject> DragObjList = new List<GameObject>();

    public int ComboCount => DragObjList.Count;

    public OrbGenerater orbGenerater = null;

    public int CurrentComboCount;
    public void AddCombo(GameObject orb)
    {
        DragObjList.Add(orb);

        foreach(var orbs in DragObjList)
        {
            if (!orbs.GetComponent<OrbController>().ComboEffect.gameObject.activeSelf)
            {
                orbs.GetComponent<OrbController>().ComboEffect.gameObject.SetActive(true);
            }

            
        }

    }
    public void MinusCombo()
    {
        DragObjList.LastOrDefault().GetComponent<OrbController>().ComboEffect.gameObject.SetActive(false);

        DragObjList.Remove(DragObjList.LastOrDefault());
    }

    public void ClearCombo()
    {
        foreach(var orbs in DragObjList)
        {
            if (orbs.GetComponent<OrbController>().ComboEffect.gameObject.gameObject)
            {
                orbs.GetComponent<OrbController>().ComboEffect.gameObject.SetActive(false);
            }

            ++CurrentComboCount;
        }
        DragObjList.Clear();
    }
}
