using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LimitTimeCountViewer : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI  m_TimeText = null;

     float m_limitTime;
    // Start is called before the first frame update
    private void Start()
    {
         m_limitTime = 60f;
    }

    // Update is called once per frame
    private void Update()
    {
        m_limitTime -= Time.deltaTime;

       m_TimeText.text = $"{m_limitTime}";
    }
}
