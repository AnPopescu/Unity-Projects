using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBanditHp : MonoBehaviour
{ public Slider Hpbar;
    float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        //Hpbar = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        Hpbar.value = Enemy.HPBandit ;
    }
    
}