using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpGaugeAutoPlacement : MonoBehaviour
{
    [SerializeField] private PickUpHPGauge m_pickUpHPGauge;

    [SerializeField] private PickUpAutoPleacement m_pickUpAutoPleacement;

    private Transform m_root = null;

    private Transform[] m_target = null;

    private bool m_placementComplete = false;


    // Start is called before the first frame update
    private void Start()
    {
        m_root = GetComponent<Transform>();

        m_placementComplete = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (m_pickUpAutoPleacement.PickupTransforms.Length == 10 && !m_placementComplete)
        {
            for (int i = 0; i < 10; i++)
            {
                var gauge = Instantiate(m_pickUpHPGauge, m_root);
                gauge.Target = m_pickUpAutoPleacement.PickupTransforms[i];
                gauge.ColliderReceiveAction = gauge.Target.GetComponent<ColliderReceiveAction>();
            }
            m_placementComplete = true;
        }
    }
}
