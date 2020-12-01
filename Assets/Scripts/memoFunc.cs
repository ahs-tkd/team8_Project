using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class memoFunc : MonoBehaviour
{
	public Text memo;

    // Start is called before the first frame update
    void Start()
    {
        showmemo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showmemo() {
    	string date_string = Calendar.DayScene_DateTime.Year.ToString()+"-"+Calendar.DayScene_DateTime.Month.ToString()+"-"+Calendar.DayScene_DateTime.Day.ToString();
        string path = Application.dataPath + @"/Data/" + date_string;
    	string file_path = path + @"/memo.txt";
    	if (!System.IO.File.Exists(file_path))
    	{
        	return;
    	}
    	// ファイルからデータを読み取る
    	string file_data = string.Empty;    // ファイルのデータ
    	using (System.IO.StreamReader sr = new System.IO.StreamReader(file_path))   // UTF-8のテキスト用
    	//using (System.IO.StreamReader sr = new System.IO.StreamReader(file_path, Encoding.GetEncoding("shift-jis")))  // シフトJISのテキスト用
    	{
        	file_data = sr.ReadToEnd(); // ファイルのデータを「すべて」取得する
    	}
    	//Console.WriteLine(file_data);
    	memo.text = file_data;
    }

    public void OnClickSaveButton()
	{
		showmemo();
	}
}
