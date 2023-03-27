using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{

    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
        if(control.num > 0.0)
        {
            anim.SetBool("New Bool", true);
        }
        else
        {
            anim.SetBool("New Bool", false);
        }
    }

}
