using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public string goal;

    public virtual bool CheckGoal()
    {
        Debug.Log("Check Goal");
        return true;
    }

}
