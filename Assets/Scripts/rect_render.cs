using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rect_render : MonoBehaviour
{
  
    void render()
    {
        SpriteRenderer sprt = gameObject.GetComponent<SpriteRenderer>();
        Debug.Log(sprt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
