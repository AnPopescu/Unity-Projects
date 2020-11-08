using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    // Start is called before the first frame update
    public static int killCounter = 0;
    Text kills;

    void Start()
    {
        kills = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        kills.text = "Kill Count: " + killCounter ;
    }
}
