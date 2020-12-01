using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;       // DateTimeを使うために必要
using System.IO;    // CSV保存をするために必要

public class saveFunction : MonoBehaviour
{
    void Start()
    {
    		// sampleDataを作って、CSVSaveの関数に引数として渡す
        var sampleData = "SampleText";
        CSVSave(sampleData, "sampleFile");
    }

		// CSV形式で保存するための関数
    private void CSVSave(string data, string fileName)
    {
        StreamWriter sw;
        FileInfo fi;
        DateTime now = DateTime.Now;
        string date_string = Calendar.DayScene_DateTime.Year.ToString()+"-"+Calendar.DayScene_DateTime.Month.ToString()+"-"+Calendar.DayScene_DateTime.Day.ToString();
        string path = Application.dataPath + @"/Data/" + date_string;
 
        if (Directory.Exists(path))
        {
            Debug.Log("Shfshtrgstgbthrgfhsrstgfhtrsompleted");
            //Console.WriteLine("存在します");
        }
        else
        {
            DirectoryInfo di = new DirectoryInfo(path);
            di.Create();
            Debug.Log("Save Completed");
            //Console.WriteLine("存在しません");
        }

        fileName = fileName + now.Year.ToString() + "_" + now.Month.ToString() + "_" + now.Day.ToString() + "__" + now.Hour.ToString() + "_" + now.Minute.ToString() + "_" + now.Second.ToString();
        fi = new FileInfo(path + "/" + fileName + ".txt");
        sw = fi.AppendText();
        sw.WriteLine(data);
        sw.Flush();
        sw.Close();
        Debug.Log("Save Completed");
    }
}