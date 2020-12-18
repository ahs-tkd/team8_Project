using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MiniJSON;
using System;

public class ButtonTest : MonoBehaviour
{
    public Text locObj;
    public string datetimeStr;

    public IEnumerator OnC() {
	Text locTxt = locObj.GetComponent<Text> ();
	datetimeStr = System.DateTime.Now.ToString();
    if (!Input.location.isEnabledByUser) {
        yield break;
    }
    Input.location.Start();
    int maxWait = 120;
    while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
        yield return new WaitForSeconds(1);
        maxWait--;
    }
    if (maxWait < 1) {
        print("Timed out");
        yield break;
    }
    if (Input.location.status == LocationServiceStatus.Failed) {
        print("Unable to determine device location");
        yield break;
    } else {
        double latitude = Input.location.lastData.latitude;
        double longitude = Input.location.lastData.longitude;
        
        WWW results = new WWW("https://aginfo.cgk.affrc.go.jp/ws/rgeocode.php?json&lat=" + latitude + "&lon=" + longitude); // 逆ジオコーディング

        yield return results;        
        var search  = Json.Deserialize(results.text) as IDictionary;
        var result = search["result"] as IDictionary;
        var prefecture = result["prefecture"] as IDictionary;
        var municipality = result["municipality"] as IDictionary;
        string currentPosition = prefecture["pname"] as string + municipality["mname"] as string;
        locTxt.text = datetimeStr + " " + currentPosition;
        }

    Input.location.Stop();

    }

    public void OnClick()
    {
        StartCoroutine("OnC");
    }
}