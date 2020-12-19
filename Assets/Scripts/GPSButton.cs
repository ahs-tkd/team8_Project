using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniJSON;
using System;
using System.IO;

public class GPSButton : MonoBehaviour
{
    public Text locObj;

    public IEnumerator OnC()
    {
        Text locTxt = locObj.GetComponent<Text>();
        Debug.Log("Before Location");
        if (!Input.location.isEnabledByUser)
        {
            locTxt.text = "GPSをONにしてください";
            yield break;
        }
        Input.location.Start();
        int maxWait = 120;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            print("Timed out");
            locTxt.text = "Time out...";
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            locTxt.text = "読み込み失敗";
            yield break;
        }
        else
        {
            locTxt.text = "位置情報読み込み完了";
            double latitude = Input.location.lastData.latitude;
            double longitude = Input.location.lastData.longitude;
            StreamWriter sw;
            FileInfo fi;
            DateTime date = System.DateTime.Now;
            string date_string = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
            string path = Application.persistentDataPath + @"/Data/" + date_string;
            fi = new FileInfo(path + @"/record.csv");
            sw = fi.AppendText();

            locTxt.text = "ファイル準備完了";
            WWW results = new WWW("https://aginfo.cgk.affrc.go.jp/ws/rgeocode.php?json&lat=" + latitude + "&lon=" + longitude); // 逆ジオコーディング

            yield return results;
            locTxt.text = "API通信完了";
            var search = Json.Deserialize(results.text) as IDictionary;
            var result = search["result"] as IDictionary;
            var prefecture = result["prefecture"] as IDictionary;
            var municipality = result["municipality"] as IDictionary;
            string currentPosition = prefecture["pname"] as string + municipality["mname"] as string;
            string content = date.ToString() + "," + currentPosition + ",GPS,";

            sw.WriteLine(content);
            sw.Flush();
            sw.Close();
            locTxt.text = "書き込み完了";
        }

        Input.location.Stop();

    }

    public void OnClick()
    {
        StartCoroutine("OnC");
    }
}