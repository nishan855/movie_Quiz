
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu_script : MonoBehaviour
{
	
public Text hsc;
void Update(){
	    
        hsc.text=PlayerPrefs.GetInt("hs",0).ToString();
    }

public void play()
    {
        
        SceneManager.LoadScene("quiz");
       
    }
}


