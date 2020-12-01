using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;     
using System.IO; 

public class SaveButtonFunc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
	{
    	StreamWriter sw;
        FileInfo fi;
        DateTime now = DateTime.Now;
        string date_string = Calendar.DayScene_DateTime.Year.ToString()+"-"+Calendar.DayScene_DateTime.Month.ToString()+"-"+Calendar.DayScene_DateTime.Day.ToString();
        string path = Application.dataPath + @"/Data/" + date_string;
    	//fileName = fileName + now.Year.ToString() + "_" + now.Month.ToString() + "_" + now.Day.ToString() + "__" + now.Hour.ToString() + "_" + now.Minute.ToString() + "_" + now.Second.ToString();
        fi = new FileInfo(path + "/memo.txt");
        sw = fi.AppendText();
        sw.WriteLine("samplesample");
        sw.Flush();
        sw.Close();
        Debug.Log("Save Completed");
	}
}
