using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbGenerater : MonoBehaviour
{
    [SerializeField] private Transform m_orbGenerater = null;

    [SerializeField] private  List<GameObject> m_orbObjects;

    [SerializeField] private  ComboCounter m_comboController = null;

    private int m_maxOrbCount = 20;

    public List<GameObject> OrbList;

    [SerializeField] private LimitTimeCountViewer LimitTimeCountViewer = null;

    [SerializeField] private ScoreViewer ScoreViewer = null;

    // Start is called before the first frame update
    void Start()
    {
        OrbGenerate(m_maxOrbCount);
    }

    private int GeneratedObj()
    {
        ///ランダムで０から１００計算
        var orbJudge = Random.Range(0, 101);

        switch (orbJudge)
        {
            case int i when i < 70:
                return Random.Range(0, 4);

            case int i when 70 < 80:
                return 5;
            default:
                return 6;
        }
    }
    public void OrbGenerate(int generateOrbCount)
    {
        for(int i = 0; i < generateOrbCount;i++)
        {
            var orb = Instantiate(m_orbObjects[Random.Range(0,6)],m_orbGenerater);

            var orbController = orb.GetComponent<OrbController>();
            orb.GetComponent<OrbController>().comboCounter = m_comboController;
            orb.GetComponent<OrbController>().OrbGenerater = this;

            orb.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-4, 4), Random.Range(-4, 0)));

           
            if (orbController.ThisOrbType == OrbController.OrbType.DevilOrb)
            {
                orbController.LimitTimeCountViewer = LimitTimeCountViewer;
                orbController.ScoreViewer = ScoreViewer;
            }
            OrbList.Add(orb);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
