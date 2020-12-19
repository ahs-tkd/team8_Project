using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;      
using System.IO;    

public class creDirFunction : MonoBehaviour
{
    void Start()
    {
        DirCreate(DateTime.Now);
        DirCreate(Calendar.DayScene_DateTime);
    }

		// CSV形式で保存するための関数 ←間違い
    // ファイル保存のためのディレクトリ生成
    private void DirCreate(DateTime date)
    {
        //StreamWriter sw;
        //FileInfo fi;
        DateTime dateTime = date;
        string date_string = date.Year.ToString()+"-"+date.Month.ToString()+"-"+date.Day.ToString();
        string path = Application.persistentDataPath + @"/Data/" + date_string;
 
        if (Directory.Exists(path))
        {
            ;
        }
        else
        {
            DirectoryInfo di = new DirectoryInfo(path);
            di.Create();
        }
    }
}