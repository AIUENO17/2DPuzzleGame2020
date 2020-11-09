using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderReceiveAction : MonoBehaviour
{
    [SerializeField] private GameObject m_thisObject = null;

    public bool IsTriggerEnter = false;

    public int DeadCount = 0;
    public int DamageCount = 0;
    // Start is called before the first frame update
    private void Awake()
    {

        m_thisObject = this.gameObject;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        DamageCount++;
     　if (DamageCount >= DeadCount)
        {
            StartCoroutine(TriggerEnter());
        }
        
        
    }
    /// <summary>
    /// 当たったら自分のgameObjectを消す
    /// </summary>
    /// <returns></returns></param>
    // Update is called once per frame
    IEnumerator TriggerEnter()
    {
        IsTriggerEnter = true;
        yield return new WaitForEndOfFrame();
        m_thisObject.SetActive(false);

    }
}
