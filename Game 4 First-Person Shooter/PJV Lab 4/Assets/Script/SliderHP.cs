using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderHP : MonoBehaviour
{   public Slider Hpbar;
    float currentHP;
    // Start is called before the first frame update
    void Start()
    {
        //Hpbar = GetComponent<Slider>();
        
    }

    // Update is called once per frame
    void Update()
    {   
        Debug.Log("CurrentHP: "+EnemySkeleton.HpforBar);
        Hpbar.value = EnemySkeleton.HpforBar;
    }
    
}
