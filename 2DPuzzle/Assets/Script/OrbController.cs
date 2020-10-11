using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class OrbController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerUpHandler
{
    private SpriteRenderer m_spriteRenderer = null;

    public ComboCounter comboCounter = null;

    public ComboCounter comboCountroller = null;
    public enum OrbType
    {
        Invalide = -1,
        BlueOrb,
        GreenOrb,
        RedOrb,
        YellowOrb,
        DevilOrb,
        SpecialOrb

    }
    public OrbType ThisOrbType = OrbType.Invalide;

    public ParticleSystem ComboEffect = null;

    public OrbGenerater OrbGenerater = null;

    public LimitTimeCountViewer LimitTimeCountViewer = null;

    public ScoreViewer ScoreViewer = null;

    private float m_DevilOrbDisapperSeconds = 6f;

    // Start is called before the first frame update
    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();

        ComboEffect.gameObject.SetActive(false);
    }

    private void Update()

    {

        if (ThisOrbType == OrbType.DevilOrb)
        {
            m_DevilOrbDisapperSeconds -= Time.deltaTime;
            if (m_DevilOrbDisapperSeconds <= 0)
            {
                OrbGenerater.OrbGenerate(1);
                this.gameObject.SetActive(false);
            }
        }
    }
    public void ShuffleAction()
    {
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)), ForceMode2D.Impulse);

    }
    // Update is called once per frame

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (ThisOrbType == OrbType.DevilOrb)
        {
            DevilAction();
            return;
        }
        if (comboCounter.DragObjList.Count.Equals(0))
        {
            return;
        }


        if (ThisOrbType == OrbType.SpecialOrb || comboCounter.DragObjList.LastOrDefault().GetComponent<OrbController>().ThisOrbType == OrbType.SpecialOrb)
        {

            //リストの中に自分がいたら帰る

            foreach (var thisObj in comboCounter.DragObjList)
            {
                if (thisObj == this.gameObject)
                {
                    return;
                }
            }
            comboCounter.AddCombo(this.gameObject);
            return;
        }

        if (comboCounter.CheckCombo(this.transform))
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

            comboCounter.CurrentComboCount += comboCounter.ComboCount;
            OrbGenerater.OrbGenerate(comboCounter.ComboCount);
        }
        comboCounter.ClearCombo();
    }

    public void DevilAction()
    {
        LimitTimeCountViewer.MinusTime();
        ScoreViewer.MinusScore();
    }
    public void OnPointerDown(PointerEventData eventData)
    {


        if (ThisOrbType == OrbType.DevilOrb)
        {
            DevilAction();
            return;
        }
        comboCounter.AddCombo(this.gameObject);
    }
}


