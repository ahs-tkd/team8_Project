using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetImage : MonoBehaviour
{
	public RawImage _rawImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetImageFromPath(@"file://" + Application.persistentDataPath + PicScroll.imgpath));
        //StartCoroutine(GetImageFromPath(@"file://" +Application.persistentDataPath + @"/Data/icon_diary.png"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void ImageUpdate(string path) {
    	StartCoroutine(GetImageFromPath(@"file://" +Application.persistentDataPath + path));
    }*/

    IEnumerator GetImageFromPath(string path)
    {
        WWW www = new WWW(path);
        yield return www;
 
        _rawImage.texture = www.textureNonReadable;
    }
}
