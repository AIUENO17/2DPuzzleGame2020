using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LimitTimeCountViewer : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI m_TimeText = null;


    public float m_limitTime;

    public float MinusSecons = 5f;

    public float PlusSeconds = 5f;
    // Start is called before the first frame update
    private void Start()
    {
        m_limitTime = 60f;
    }


    public void MinusTime()
    {

        m_limitTime -= MinusSecons;

    }

    public void PlusTime()
    {
        m_limitTime += PlusSeconds;
    }
    // Update is called once per frame
    private void Update()
    {
        m_limitTime -= Time.deltaTime;

       m_TimeText.text = $"{m_limitTime}";
    }
}
