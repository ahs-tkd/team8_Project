using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ShowDay : MonoBehaviour
{
    public Text Day;

    // Start is called before the first frame update
    void Start()
    {
        DateTime datetime = DateTime.Now;
        Day.text = datetime.Year.ToString() + "年" + datetime.Month.ToString() + "月" + datetime.Day.ToString() + "日";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
