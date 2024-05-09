using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TimeTravel : MonoBehaviour
{
    
    [SerializeField] GameObject present, past;
    [SerializeField] bool presentIsVisible = true;

    
    float timeToEffect = 0f;
    [SerializeField] float effectRatePerSecond = 1;

    
    //[SerializeField] Volume effectVolume;
    [SerializeField] float transitionTime = 10f; 

    void Start()
    {
       
        present.SetActive(presentIsVisible);
        past.SetActive(!presentIsVisible);
    }

    void Update()
    {
        
        if (Input.GetButtonDown("Fire1") && Time.time >= timeToEffect)
        {
            timeToEffect = Time.time + 1 / effectRatePerSecond;
           
            SwitchActiveLayers();
           
            PlayEffect();
        }
    }

   
    void SwitchActiveLayers()
    {
        presentIsVisible = !presentIsVisible;
        present.SetActive(!present.activeSelf);
        past.SetActive(!past.activeSelf);
    }

   
    void PlayEffect()
    {
        //effectVolume.weight = 1;
        Invoke("TurnOffVolume", transitionTime);
    }

   
    void TurnOffVolume()
    {
        //effectVolume.weight = 0;
    }
}