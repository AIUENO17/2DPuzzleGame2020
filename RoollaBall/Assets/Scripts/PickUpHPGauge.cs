using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpHPGauge : MonoBehaviour
{
    public ColliderReceiveAction ColliderReceiveAction = null;

    public Transform Target = null;

    private Image m_thisGauge = null;

    private RectTransform m_rect = null;

    private Vector3 m_offset = new Vector3(0, 1, 0);

    private void Start()
    {
        m_thisGauge = gameObject.GetComponent<Image>();

        m_rect = GetComponent<RectTransform>();
    }
    private void Update()
    {
        m_rect.position = RectTransformUtility.WorldToScreenPoint(Camera.main, Target.position + m_offset);

        if (ColliderReceiveAction == null || ColliderReceiveAction.DamageCount == 0)
        {
            return;
        }

        m_thisGauge.fillAmount = (ColliderReceiveAction.DeadCount - ColliderReceiveAction.DamageCount) / (float)ColliderReceiveAction.DeadCount;
    }
}
