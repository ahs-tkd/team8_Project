using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //カメラ表示開始
        webCam.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
