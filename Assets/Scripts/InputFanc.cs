using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class InputFanc : MonoBehaviour
{
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnClickSaveButton()
	{
    	StreamWriter sw;
        FileInfo fi;
        string date_string = Calendar.DayScene_DateTime.Year.ToString()+"-"+Calendar.DayScene_DateTime.Month.ToString()+"-"+Calendar.DayScene_DateTime.Day.ToString();
        DateTime datetime = DateTime.Now;
        string path = Application.persistentDataPath + @"/Data/" + date_string;
    	//fileName = fileName + now.Year.ToString() + "_" + now.Month.ToString() + "_" + now.Day.ToString() + "__" + now.Hour.ToString() + "_" + now.Minute.ToString() + "_" + now.Second.ToString();
        fi = new FileInfo(path + @"/record.csv");
        sw = fi.AppendText();
        sw.WriteLine(datetime.ToString() + "," + inputField.text + ",メモ,");
        sw.Flush();
        sw.Close();
        Debug.Log("Save Completed");
        inputField.text = string.Empty;
	}
}
