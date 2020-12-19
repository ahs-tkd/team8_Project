using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class CameraStart : MonoBehaviour
{

	public RawImage RawImage;
    WebCamTexture webCam;

    // Start is called before the first frame update
    void Start()
    {
        // WebCamTextureのインスタンスを生成
        webCam = new WebCamTexture();
        //RawImageのテクスチャにWebCamTextureのインスタンスを設定
        RawImage.texture = webCam;

        //90度カメラ回転
        Vector3 angles = RawImage.GetComponent<RectTransform>().eulerAngles;
        angles.z = -90;
        RawImage.GetComponent<RectTransform>().eulerAngles = angles;
        //カメラ表示開始
        webCam.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickShotButton()
    {
        // カメラ停止
        webCam.Pause();

        //データ保存
        // Texture2Dを新規作成
        Texture2D texture = new Texture2D(webCam.width, webCam.height, TextureFormat.ARGB32, false);
        // カメラのピクセルデータを設定
        texture.SetPixels(webCam.GetPixels());
        // TextureをApply
        texture.Apply();

        // Encode
        byte[] bin = texture.EncodeToJPG();
        // Encodeが終わったら削除
        //Object.Destroy(texture);

        // ファイルを保存
        DateTime now = DateTime.Now;
        File.WriteAllBytes(Application.persistentDataPath + "/pic"+ now.Hour.ToString() + "-" + now.Minute.ToString() + "-" + now.Second.ToString() + "-" + ".jpg", bin);

        //メモ記入
        StreamWriter sw;
        FileInfo fi;
        DateTime date = System.DateTime.Now;
        string date_string = date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
        string path = Application.persistentDataPath + @"/" + date_string;
        fi = new FileInfo(path + @".csv");
        sw = fi.AppendText();
        string content = date.ToString() + "," + path + "に画像保存,カメラ,";

        sw.WriteLine(content);
        sw.Flush();
        sw.Close();

        SceneManager.LoadScene("title");
    }
}
