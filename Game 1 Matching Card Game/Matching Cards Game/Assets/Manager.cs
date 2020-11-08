using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{   public Sprite cardBack;
    public Sprite[] cardFront;
    public GameObject[] cards;
    public int victorie;
    
    
    public Text potriviri;
    public  Text Score;
    public  int ScoreC;
    public Text Timer;
    
    

    
    
    
    void initializeCards() {
    int index=0;
    for(int id=0;id<2;id++)
        { 
     for(int i=0;i<8;i++)
            {
                cards[index].GetComponent<CardRandom> ().valoare = i;
                cards[index].GetComponent<CardRandom> ().indek = index;
                index++;
                
            }
        }
    }
    void Shuffle (GameObject[] deck) {
        for (int i = 0; i < deck.Length; i++) {
            GameObject temp = deck[i];
            Random.InitState(System.DateTime.Now.Millisecond);
            int randomIndex = Random.Range(0, deck.Length);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
            
        }
    }

    void checkCards() {
        
        List<int> c = new List<int>();

        for(int i=0;i<cards.Length;i++){
            if(cards[i].GetComponent<CardRandom>().intoarsa==1&&cards[i].GetComponent<CardRandom>().activa==1)
            c.Add(i);
        }
        if(c.Count==2)
        Comparatie(c);
        
        
            
        }
        

    public Sprite getCarteSpate(){
        return cardBack;
    }
    public Sprite getCarteFata(int k){

        return cardFront[k];
        
    }
    void Comparatie(List<int> c){
                
                if(cards[c[0]].GetComponent<CardRandom> ().valoare == cards [c[1]].GetComponent<CardRandom> ().valoare)
                { cards[c[0]].GetComponent<CardRandom> ().activa = 0 ;
                  cards[c[1]].GetComponent<CardRandom> ().activa = 0  ;
                  victorie++;
                  ScoreC+=(100 + (int)GetComponent<TimeE>().targetTime *4);
                  Score.text = "Score: "+ ScoreC;
                  potriviri.text = "Number of matches: "+victorie;
                  c.Clear();
                  if(victorie==8){
                  SceneManager.LoadScene("MenuBun");
                  }
                  


                }else  {StartCoroutine(Fade(c));
                       
                      }


                //if(cards[].GetComponent<CardRandom>().valoare==cards[].GetComponent<CardRandom>().valoare){


                }


            //         victorie++;
            //         Debug.Log("Potriviri:"+victorie);
            //         CardRandom.matches = 0;
                    
            //     } else 
            //     {
            //         cards[compare[0]].GetComponent<CardRandom>().IntoarceSpatele();
            //         cards[compare[1]].GetComponent<CardRandom>().IntoarceSpatele();
            //         CardRandom.matches = 0;
            //     }

            // }
    
         
            
   
   
    IEnumerator Fade(List<int> c) 
{       
        
        yield return new WaitForSeconds(1);
        cards[c[0]].GetComponent<CardRandom> ().IntoarceSpatele();
                       cards[c[0]].GetComponent<CardRandom> ().intoarsa=0;
                       cards[c[1]].GetComponent<CardRandom> ().IntoarceSpatele();
                       cards[c[1]].GetComponent<CardRandom> ().intoarsa=0;
                       c.Clear();
    
}


    void Start(){
        Shuffle(cards);
        Shuffle(cards);
        Shuffle(cards);
        Shuffle(cards);
        initializeCards();
        
        

    }
    void Update(){
       checkCards();
       Timer.text = "Timer: " + (int)GetComponent<TimeE>().targetTime;
       
        
    }
    }


