using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardRandom : MonoBehaviour
{   
   // public Sprite[] images;
    int i;
    public int indek;
    int choice;
    public int valoare;
    public static int matches;
    public static int[] match;
    private int match2;
    public Sprite CarteFata;
    public Sprite CarteSpate;
    private GameObject _manager;
  
    public int state = 1;
    
    public int intoarsa;
    public int activa = 1 ;
    
    
    void Start(){

    _manager = GameObject.FindGameObjectWithTag("Aici");
     
    }
    void Update(){
      
      seteazaSpate();
      SeteazaFata();
      
    }
    // public void initializare(){
    
    //             for (int i = 0; i < 8; i++)
    //         {   
    //             Random.InitState(System.DateTime.Now.Millisecond) ;
    //             choice=Random.Range(0,3);
    //             gameObject.GetComponent<Image> ().sprite = images[choice];
                
                
    //         }

    // }
    void seteazaSpate(){
    CarteSpate = _manager.GetComponent<Manager> ().getCarteSpate ();
    }
    
    public void SeteazaFata(){
      CarteFata = _manager.GetComponent<Manager>().getCarteFata(valoare);
      
    }
    // public void stematches(){

    //     matches = 0;

    // }
    public void intoarce(){
      
        this.intoarsa = 1;

        GetComponent<Image> ().sprite = CarteFata;
        

      }
      
      
      
    
    public int getIndek(){
      return this.indek;

    }
    public void IntoarceSpatele(){

      gameObject.GetComponent<Image> ().sprite = CarteSpate;
      

    }
    
     
}
