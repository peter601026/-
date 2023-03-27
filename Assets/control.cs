using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;
public class control : MonoBehaviour
{
    Rigidbody rigid3D;
    
    static public float a;
    float b;
    string c;
    static public float num;
    void Start()
    {
        rigid3D = this.gameObject.GetComponent<Rigidbody>();
    }

   
    void Update()
    {
        b += Time.deltaTime;
        a = Mathf.Abs(transform.position.x + 44.5f) ;
        c = ArduinoBasic.readMessage;
        num = int.Parse(c);
        num = num / 200;
        rigid3D.AddForce(new Vector3(1*num ,0,0), ForceMode.Force);
        
        if(rigid3D.transform.position.x > 38)
        {
            SceneManager.LoadScene(2);
        }
        if(b > 40.0f)
        {
            SceneManager.LoadScene(2);
        }
        
    }
}
