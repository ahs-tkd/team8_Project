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
        StartCoroutine(GetImageFromPath(Application.persistentDataPath + @"/Data/icon_diary.png"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetImageFromPath(string path)
    {
        WWW www = new WWW(path);
        yield return www;
 
        _rawImage.texture = www.textureNonReadable;
    }
}
