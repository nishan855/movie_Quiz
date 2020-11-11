
using System.Globalization;
using System.Reflection;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class question : MonoBehaviour
{
    public Image im1;
    public Image im2;
    public List<Sprite> image1;
    public List <Sprite> image2;


    public GameObject opt1;
    public GameObject opt2;
    public GameObject opt3;
    public GameObject opt4;

    public GameObject quit;
    public List<Text> buttontext;

    public AudioClip right;
    public AudioClip suspense;
    public AudioClip wrong;

    public int i = 2;
    

    private void Start_game()
    {
        Show_question();
    }

    private void Show_question()
    {
        ++i;
        //increase question
        Console.WriteLine(i);
        im1.sprite = image1[i];
        im2.sprite = image2[i];
        //ifend show game over

        //set answer

        //set options
    }
}
