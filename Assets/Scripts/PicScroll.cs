using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicScroll : MonoBehaviour
{
	public GameObject canvas;
	public GameObject pref_rI;

	//RawImage _rawImage;

	public static string imgpath;
	string[] img_path;// = new string[2] {"/Data/icon_diary.png", "/Data/no_image.jpg"};

    // Start is called before the first frame update
    void Start()
    {
    	img_path = new string[] {"/Data/icon_diary.png", "/Data/fish.JPG", "/Data/pig.png"};
        for (int i = 0; i < img_path.Length; i++)
        {
        	imgpath = img_path[i];//画像埋め込み
            GameObject rawImage = Instantiate(pref_rI, canvas.transform);
            rawImage.GetComponent<RawImage>();
        }

        //画像埋め込み
        //Debug.Log(img_path.Length);
        for (int i = 0; i < img_path.Length; i++)
        {

            Transform RI = GameObject.Find("GameObject").transform.GetChild(i);
            //rawImage =
            RawImage ri = 
            RI.GetComponent<RawImage>();
            Debug.Log(i);
            Debug.Log(img_path[i]);
            　
            
            //StartCoroutine(GetImageFromPath(@"file://" + Application.persistentDataPath + @"/Data/pig.png"));
            StartCoroutine(GetImageFromPath(@"file://" + Application.persistentDataPath + @"/" +img_path[i], ri));
        }//*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetImageFromPath(string path, RawImage _rawImage)
    {
        WWW www = new WWW(path);
        yield return www;
        _rawImage.texture = www.textureNonReadable;
    }
}
