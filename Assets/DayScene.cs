using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DayScene : MonoBehaviour
{
    public Text DayText;

    // Start is called before the first frame update
    void Start()
    {
        DayText.text = Calendar.DayScene_DateTime.Year.ToString()+"年 "+Calendar.DayScene_DateTime.Month.ToString()+"月 "+Calendar.DayScene_DateTime.Day.ToString()+"日";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
