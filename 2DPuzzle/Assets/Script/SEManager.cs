using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public AudioSource[] m_audioSouce = new AudioSource[2];

    public AudioClip BombSE = null;

    public AudioClip BGM = null;

    private void Start()
    {
        m_audioSouce[1].clip = BGM;
        m_audioSouce[1].loop = true;
        m_audioSouce[1].Play();
    }
    public void PlaySE()
    {
        m_audioSouce[0].clip = BombSE;
        m_audioSouce[0].Play();
    }



}