using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class right : MonoBehaviour
{
    public Text scor;
    public Text correc;
    public ques q;

    public void Main()
    {
        scor.text = ques.sc.ToString();
        correc.text = ques.count.ToString();
    }

    public void onclick()
    {
       q.Show_question(); 
        
    }
    
}
