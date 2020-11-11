using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Wrong : MonoBehaviour
{    public Text scor;
    public Text correc;
    public Text hs;
   
    public void Main()
    {   PlayerPrefs.SetInt("highscore",ques.sc);
        scor.text = ques.sc.ToString();
        correc.text=ques.count.ToString();
        
    }
    public void playagain(){
    
    SceneManager.LoadScene("last");
    }
}
