using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPCounter : MonoBehaviour
{
    // Start is called before the first frame update
    Text Hptext;
    void Start()
    {
        Hptext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Hptext.text = "HP: " + PlayerHP.HP;
    }
}
