 using UnityEngine;
 using System.Collections;
 using UnityEngine.SceneManagement;
 
 public class TimeE: MonoBehaviour {
 
 public  float targetTime = 60;
 
 void Update(){
 
 targetTime -= Time.deltaTime;
 
 if (targetTime <= 0.0f)
 {
    timerEnded();
 }
 
 }
 
 void timerEnded()
 {
    SceneManager.LoadScene("Restart");
 }
 
 
 }