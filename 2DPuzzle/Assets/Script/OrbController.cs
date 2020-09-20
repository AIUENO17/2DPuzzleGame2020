using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class OrbController : MonoBehaviour, IPointerDownHandler,IPointerEnterHandler,IPointerUpHandler
{
    private SpriteRenderer m_spriteRenderer = null;

    public ComboCounter comboCounter = null;

    public ComboCounter comboCountroller  = null;
    public enum OrbType
    {
        Invalide =-1,
        BlueOrb,
        GreenOrb,
        RedOrb,
        YellowOrb,
    }
    public OrbType ThisOrbType = OrbType.Invalide;

     public  ParticleSystem ComboEffect = null;

    public OrbGenerater OrbGenerater = null;


    // Start is called before the first frame update
    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();

        ComboEffect.gameObject.SetActive(false);
    }

    // Update is called once per frame
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (comboCounter.DragObjList.Count.Equals(0))
        {
            return;
        }
        if (comboCounter.DragObjList.Contains(this.gameObject))
        {
            if (comboCounter.DragObjList.Count.Equals(1))
            {
                return;
            }
            comboCounter.MinusCombo();
            return;
        }

        if (comboCounter.DragObjList.FirstOrDefault().GetComponent<OrbController>().ThisOrbType != ThisOrbType)
        {
            return;
        }

        comboCounter.AddCombo(this.gameObject);
    }



    public void OnPointerUp(PointerEventData eventData)
    {
        if (comboCounter.ComboCount > 2)
        {
            foreach (var orb in comboCounter.DragObjList)
            {
                orb.SetActive(false);
            }

            OrbGenerater.OrbGenerate(comboCounter.ComboCount);
        }
        comboCounter.ClearCombo();
        }

    public void OnPointerDown(PointerEventData eventData)
    {
        comboCounter.AddCombo(this.gameObject);
    }
}

    
