using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicScroll : MonoBehaviour
{
	public GameObject canvas;
	public GameObject pref_rI;

	public string[] img_path;// = new string[2] {"/Data/icon_diary.png", "/Data/no_image.jpg"};
	//int[] numbers = new int[3] { 4, 5, 6 }; 

    // Start is called before the first frame update
    void Start()
    {
    	img_path = new string[2] {"/Data/icon_diary.png", "/Data/no_image.jpg"};
        for (int i = 0; i < img_path.Length; i++)
        {

            GameObject rawImage = Instantiate(pref_rI, canvas.transform);
            rawImage.GetComponent<RawImage>();
            //Transform Picture = GameObject.Find("GameObject").transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
