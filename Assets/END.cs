using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class END : MonoBehaviour
{
    
    public float a;
    public float b;
    public Text text;
    void Start()
    {
        
    }

    
    void Update()
    {
        a = control.a;
        if (a > 82)
        {
            b =100;
        }
        else
        {
           b = a / 82 * 100;
           
        }
        text.text = "¤À¼Æ : " + (int)b;
    }
}
