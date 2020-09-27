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

        foreach (var orbs in DragObjList)
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
        foreach (var orbs in DragObjList)
        {
            if (orbs.GetComponent<OrbController>().ComboEffect.gameObject.gameObject)
            {
                orbs.GetComponent<OrbController>().ComboEffect.gameObject.SetActive(false);
            }

            CurrentComboCount++;
        }
        DragObjList.Clear();
    }

    /// <summary>
    ///magunitudeで二点間の距離求める
    ///玉の最後の距離と二個目の距離を‐する
    ///２．０以上の距離は消えないようにする
    ///Debug.logで距離を求める
    ///(pos1 - pos2).magnitudeが公式
    ///float型の変数diff
    ///
    ///
    /// </summary>
    /// <param name="thisOrbTransform"></param>
    /// <returns></returns>
    public bool CheckCombo(Transform thisOrbTransform)
    {
        float diff = (DragObjList.LastOrDefault().transform.position - thisOrbTransform.position).magnitude;
        Debug.Log("きょりは＞？"+ diff);

        return diff >= 2.0f;

    }
}