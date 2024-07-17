using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using nn.oe;

public class Timer : MonoBehaviour
{

    public Text CountText;
    float countdown = 3f;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(countdown>=0)
        {
            countdown -= Time.deltaTime;
            count = (int)countdown;
            CountText.text = count.ToString();          
        }
       
    }
}
