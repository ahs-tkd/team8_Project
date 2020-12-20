using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PicScroll : MonoBehaviour
{
	public GameObject canvas;
	public GameObject pref_rI;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject rawImage = Instantiate(pref_rI, canvas.transform);
            rawImage.GetComponent<RawImage>();
            Transform Picture = GameObject.Find("GameObject").transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
