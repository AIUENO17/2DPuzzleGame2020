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

    // Start is called before the first frame update
    void Start()
    {
        OrbGenerate(m_maxOrbCount);
    }
    public void OrbGenerate(int generateOrbCount)
    {
        for(int i = 0; i < generateOrbCount;i++)
        {
            var orb = Instantiate(m_orbObjects[Random.Range(0,4)],m_orbGenerater);

            orb.GetComponent<OrbController>().comboCounter = m_comboController;
            orb.GetComponent<OrbController>().OrbGenerater = this;

            orb.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-4, 4), Random.Range(-4, 0)));

            OrbList.Add(orb);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
