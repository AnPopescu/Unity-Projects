using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReloadUI : MonoBehaviour
{
    // Start is called before the first frame update
    Text reloadText;

    void Start()
    {
        reloadText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {   if(Gunz.isreloading)
        reloadText.text = "Reloading...";
        else
        {
            reloadText.text = Gunz.currentAmmo + "/00";
        }
    }
}
