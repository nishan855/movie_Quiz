using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Resources;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ques : MonoBehaviour
{

    public  Image imagequestion;
    public  Image imagequestion2;
    public  Text name1;
    public Text name2;
    public  List<Sprite> spr1;
    public  List<Sprite> spr2;
    public  int index;
    public List<string> answer;
    public  List<string> rf;
    public List<Text> opt1;
    public List<Button> opt;
    public GameObject quit;
    public  string correct;
    public  string selected_ans;
    public AudioClip aud_cor;
    public AudioClip aud_wr;
    public AudioClip aud_sus;
    public AudioClip tap;
    public AudioSource ad;
    public Text corrr;
    public static int count = 0;
    public Text score;
    public static int sc=0;
    private int button_clicked =0;
    public List<int> choice;
    private int ind = -1;
    private bool isplaying = true;
    public Color rt_color;
    public Color wr_color;
    public Image checker;
    public Text check;
    public string st;
    private int it;
    


    public void Start()
    {   
        ad = GetComponent<AudioSource>();
        if (isplaying == true)
        {
            ad.Play();
        }

        Show_question();
        
    }

    public void Show_question()

    {
        ad.loop = true;
        ad.clip = aud_sus;
        ad.Play();
        

        ++ind;
        button_clicked = 0;
        score.text = sc.ToString();
        corrr.text = count.ToString();
        for (int i = 0; i < 4; i++)
        {
            ColorBlock colorBlock = opt[i].GetComponent<Button>().colors;
            colorBlock.normalColor = Color.white;
            opt[i].GetComponent<Button>().colors = colorBlock;
        }

        checker.color = Color.white;
        check.text = "Let's Go!";
        st = "Let's Go";
        
        //countdown();

        
            //set name
            name1.text = spr1[ind].name;
            name2.text = spr2[ind].name;

            //set images
            imagequestion.sprite = spr1[ind];
            imagequestion2.sprite = spr2[ind];
            rf = read_file();
            answer = new List<string>();
            string text = rf[ind];
            string[] option = text.Split(',');
            correct = option[0];

            //set options
            answer.Add(correct);
            answer.Add(option[1]);
            answer.Add(option[2]);
            answer.Add(option[3]);





            Position_answer();

            for (int i = 0; i < 4; i++)
            {
                opt1[i].text = answer[i];
            }
            
    }
    

        //randomly assign answer to a option
    private void Position_answer()
    {
        string correct = answer[0];
        int random = UnityEngine.Random.Range(0, 4);
        string rands = answer[random];
        answer[random] = correct;
        answer[0] = rands;

    }



    private void Show_all()
    {
        imagequestion.gameObject.SetActive(true);
        imagequestion2.gameObject.SetActive(true);
        name1.gameObject.SetActive(true);
        name2.gameObject.SetActive(true);

        for (int i = 0; i < 4; i++)
        {
            opt[i].gameObject.SetActive(true);
        }
        
        

        quit.gameObject.SetActive(true);


    }

    private void Hide_prev()
    {
        imagequestion.gameObject.SetActive(false);
        imagequestion2.gameObject.SetActive(false);
        name1.gameObject.SetActive(false);
        name2.gameObject.SetActive(false);

        for (int i = 0; i < 4; i++)
        {
            opt[i].gameObject.SetActive(false);
        }

        quit.gameObject.SetActive(false);
    }

    private List<string> read_file()
    {

        var list = new List<string>();
        var fileStream = new FileStream(@"C:\Users\nisha\Documents\LD_quiz\Assets\Resources\correct_answer.txt",
            FileMode.Open, FileAccess.Read);
        using (var streamReader = new StreamReader(fileStream))
        {
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                list.Add(line);
            }
        }

        return list;

    }

    private bool CheckAnswer()
    {
        if (selected_ans.Equals(correct))
        {
            return true;

        }
        else
        {
            return false;
        }
    }


    public void OnoptAclick()
    {
        button_clicked = 1;
        it = 0;
        selected_ans = opt1[0].text;
        ad.loop = false;
        ad.clip = tap;
        ad.Play();

        if (CheckAnswer())
        {   
            ColorBlock colorBlock = opt[it].GetComponent<Button>().colors;
            colorBlock.normalColor = Color.yellow;
            opt[0].GetComponent<Button>().colors = colorBlock;
            Invoke("when_correct", 1f);
            //ColorBlock colorBlock = opt[0].GetComponent<Button>().colors;
            //colorBlock.normalColor = Color.green;
            
            //opt[0].GetComponent<Button>().colors = colorBlock;
            //count++;
            //sc +=10 + end_time * 1;
            Hide_prev();
            //Invoke ("Hide_prev",5f);
            //SceneManager.LoadScene("Correct");
            //Show_question();
            Invoke("Show_question", 2f);
            Invoke("up",2f);
            Show_all();
            selected_ans = "";

        }
        else
        {   ColorBlock cb = opt[it].GetComponent<Button>().colors;
            cb.normalColor = Color.yellow;
            opt[0].GetComponent<Button>().colors = cb;
            Invoke("sleep",0.5f);
            Invoke("Playwrong", 1f);
        }
        

    }

    public void OnoptBclick()
    {
        selected_ans = opt1[1].text;
        button_clicked = 1;
        it = 1;
        
        ad.loop = false;
        ad.clip = tap;
        ad.Play();
        if (CheckAnswer())

        {   ColorBlock colorBlock = opt[it].GetComponent<Button>().colors;
            colorBlock.normalColor = Color.yellow;
            opt[1].GetComponent<Button>().colors = colorBlock;
            Invoke("when_correct", 1f);
            //ColorBlock colorBlock = opt[1].GetComponent<Button>().colors;
            //colorBlock.normalColor = Color.green;
            //ad.loop = false;
            //ad.clip = aud_cor;
            //opt[1].GetComponent<Button>().colors = colorBlock;
            //count++;
            //sc +=10 + end_time * 1;
            //Invoke ("Hide_prev",5f);
            Hide_prev();
            Invoke("Show_question", 2f);
            Invoke("up",2f);
            Show_all();
            

            selected_ans = "";
            
            


        }
        else
        {   ColorBlock cb = opt[it].GetComponent<Button>().colors;
            cb.normalColor = Color.yellow;
            opt[1].GetComponent<Button>().colors = cb;
            Invoke("sleep",0.5f);
            Invoke("Playwrong", 1f);

            
        }
        
    }

    public void OnoptCclick()
    {
        selected_ans = opt1[2].text;
        button_clicked = 1;
        it = 2;
       
        ad.loop = false;
        ad.clip = tap;
        ad.Play();

        if (CheckAnswer())
        {    ColorBlock colorBlock = opt[2].GetComponent<Button>().colors;
            colorBlock.normalColor = Color.yellow;
            opt[2].GetComponent<Button>().colors = colorBlock;
            Invoke("when_correct", 1f);
            //ColorBlock colorBlock = opt[2].GetComponent<Button>().colors;
            //ad.loop = false;
            //ad.clip = aud_cor;
            //colorBlock.normalColor = Color.green;
            //opt[2].GetComponent<Button>().colors = colorBlock;
            //count++;
            //sc +=10 + end_time * 1;
            Hide_prev();
            Invoke("Show_question", 2f);
            Invoke("up",2f);
            //Show_question();
            Show_all();
            selected_ans = "";
            

        }
        else
        {   ColorBlock cb = opt[it].GetComponent<Button>().colors;
            cb.normalColor = Color.yellow;
            opt[2].GetComponent<Button>().colors = cb;
          
            Invoke("sleep",0.5f);
            Invoke("Playwrong", 1f);

        }
        

    }

    public void OnoptDclick()
    {
        selected_ans = opt1[3].text;
        button_clicked = 1;
        it = 3;
       
        ad.loop = false;
        ad.clip = tap;
        ad.Play();
        
        if (CheckAnswer())
        {    ColorBlock colorBlock = opt[it].GetComponent<Button>().colors;
            colorBlock.normalColor = Color.yellow;
            opt[3].GetComponent<Button>().colors = colorBlock;
            
            Invoke("when_correct", 1f);
            //ColorBlock colorBlock = opt[3].GetComponent<Button>().colors;
            //colorBlock.normalColor = Color.green;
           // ad.loop = false;
            //ad.clip = aud_cor;
            //opt[3].GetComponent<Button>().colors = colorBlock;
            //count++;
            //sc +=10 + end_time * 1;
            Hide_prev();
            Invoke("Show_question",2f);
            Invoke("up",2f);

            Show_all();
            
            
            
            selected_ans = "";
            
        }
        else
        
        {   ColorBlock cb = opt[it].GetComponent<Button>().colors;
            cb.normalColor = Color.yellow;
            opt[3].GetComponent<Button>().colors = cb;
            Invoke("sleep",0.5f);
            Invoke("Playwrong", 1f);

            
            


        }
        
        

    }

    public Text counter;
    public float current_time = 16f;
    public int end_time;

    

    private int  Update()
    {
        if (button_clicked==0&& current_time>0.0f)
        {
            current_time -= Time.deltaTime;
            end_time = (int) current_time;
            counter.text = end_time.ToString();

        }

        else if (button_clicked == 1)
        {
            end_time = (int) current_time;
            counter.text = end_time.ToString();
            
        }

        else
        {
            SceneManager.LoadScene("timeup");
        }

        return end_time;
        }

    private void up()
    {
        current_time = 16f;
        end_time = (int) current_time;
    }

    private void Playwrong()
    {
        SceneManager.LoadScene("Incorrect");
    }

    private void when_correct()
    {
        st = "CORRECT";
        checker.color = Color.green;
        check.text = "CORRECT";
        ColorBlock colorBlock = opt[it].GetComponent<Button>().colors;
        colorBlock.normalColor = Color.green;
        ad.loop = false;
        ad.clip = aud_cor;
        opt[it].GetComponent<Button>().colors = colorBlock;
        count++;
        sc +=10 + end_time * 1;
        ad.Play();
        
    }

    private void when_wrong()
    {
        st = "WRONG";
        checker.color = Color.red;
        check.text = "WRONG";
        ColorBlock colorBlock = opt[it].GetComponent<Button>().colors;
        colorBlock.normalColor = Color.red;
        ad.loop = false;
        ad.clip = aud_wr;
        opt[it].GetComponent<Button>().colors = colorBlock;
        ad.Play();
        PlayerPrefs.SetInt("correct",count);
        PlayerPrefs.SetInt("Score",sc);
    }

    private void sleep()
    {
        System.Threading.Thread.Sleep(500);
    }



}
   
