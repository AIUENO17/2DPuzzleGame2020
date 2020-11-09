using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePresenter : TimeCount
{

    [SerializeField] private Text m_timeText = null;
    // Start is called before the first frame update
    

    // Update is called once per frame
   public override void Update()
    {
        base.Update();
        m_timeText.text = $"{TimeUpdateCounts}";
    }
}
