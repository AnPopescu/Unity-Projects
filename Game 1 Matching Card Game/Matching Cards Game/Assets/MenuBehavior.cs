using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public void triggerMenuBehavior(int i){
        switch(i)
        {
            case(0):
            SceneManager.LoadScene("Inceput");
            break;
            case(1):
            Application.Quit();
            break;



        }
        
    }
}
