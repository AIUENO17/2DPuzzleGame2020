   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereAttack : MonoBehaviour
{

    [SerializeField] private GameObject m_bullet = null;
    [SerializeField] private GameObject m_sphere = null;
    [SerializeField] private float m_bulletSpeed = 30;
    private bool m_isFire = false;


    // Start is called before the first frame update
    private  void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_isFire = true;
        }
        
    }

    // Update is called once per frame
   private  void Update()
    {
        var diffPos = transform.position - m_sphere.transform.position;
        if (diffPos.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(-diffPos);
        }
        transform.position = m_sphere.transform.position;

        if (m_isFire)
        {
            var bullet = Instantiate(m_bullet);
            bullet.transform.position = transform.position + transform.position;
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * m_bulletSpeed;
            m_isFire = false;
        }
    }
}
