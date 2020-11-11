using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class last_script : MonoBehaviour
{
   public Text correct;
   public Text hs;
   public Text score;
   
  
   
   public void Start()
   {
   	correct.text=ques.count.ToString();
   	score.text=ques.sc.ToString();
   	if(ques.sc>PlayerPrefs.GetInt("hs",0))
   	   {
  
   	   	PlayerPrefs.SetInt("hs",ques.sc);
   	   	
   	   }
   	   hs.text=PlayerPrefs.GetInt("hs",0).ToString();
   	   ques.sc=0;
   	   ques.count=0;
   	}
   	
   public void playagain(){
    
    SceneManager.LoadScene("Menu");
    }
}
