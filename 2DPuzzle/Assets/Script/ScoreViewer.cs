using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    ComboCounter m_comboCounter => GetComponent<ComboCounter>();

        [SerializeField] TextMeshProUGUI m_scoerText = null;

    public int Score;

    public int MinusCombo = 5;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        m_scoerText.text = $"{m_comboCounter.CurrentComboCount}";
        Score = m_comboCounter.CurrentComboCount;
    }

    public void MinusScore()
    {
        m_comboCounter.CurrentComboCount -= MinusCombo;
    }
}
