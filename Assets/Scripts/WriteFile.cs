using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class WriteFile : MonoBehaviour
{
    public Text memo;
    public Text buttonText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WriteAndRead(string content, string attribute)
    {
        StreamWriter sw;
        FileInfo fi;
        DateTime datetime = DateTime.Now;
        string date_string = datetime.Year.ToString() + "-" + datetime.Month.ToString() + "-" + datetime.Day.ToString();
        string file_path = Application.persistentDataPath + "/" + date_string + ".csv";
        fi = new FileInfo(file_path);
        sw = fi.AppendText();
        sw.WriteLine(datetime.ToString() + "," + content + "," + attribute + ",");
        sw.Flush();
        sw.Close();
        Debug.Log("Save Completed");


    	if (!System.IO.File.Exists(file_path))
    	{
        	return;
    	}
    	// ファイルからデータを読み取る
    	string file_data = string.Empty;    // ファイルのデータ
    	using (System.IO.StreamReader sr = new System.IO.StreamReader(file_path))   // UTF-8のテキスト用
    	{
        	file_data = sr.ReadToEnd(); // ファイルのデータを「すべて」取得する
    	}
        if (memo != null)
        {
    	    memo.text = file_data;
        }
    }

    public void OnClickGoOutButton()
    {
        string content = "外出しました";
        string attribute = "外出";
        WriteAndRead(content, attribute);
        buttonText.text = "OK";
    }

    public void OnClickGoHomeButton()
    {
        string content = "帰宅しました";
        string attribute = "帰宅";
        WriteAndRead(content, attribute);
        buttonText.text = "OK";
    }

    public void OnClickMemoSaveButton(InputField inputField)
    {
        string content = inputField.text;
        string attribute = "メモ";
        WriteAndRead(content, attribute);
        inputField.text = string.Empty;
        buttonText.text = "保存完了";
    }
}
