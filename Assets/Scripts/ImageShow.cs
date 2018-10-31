using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class ImageShow : MonoBehaviour {
    Sprite[] array;
    public int charaNum;
    public string folderName;
    int index;
    public CharacterNavigation navi;
	// Use this for initialization
	void Start () {
        //placeholder.texture = Resources.
        array = new Sprite[charaNum+1];
        array[0] = gameObject.GetComponent<SpriteRenderer>().sprite;
        for (int x = 1; x<=charaNum; x++)
        {
            string tempname = "Player Select/" + folderName + "/" + (x);
            array[x] = Resources.Load<Sprite>(tempname) as Sprite;
        }
    }
	
	// Update is called once per frame
	void Update () {
        index = navi.GetIndex();
        string name = index.ToString();
        if (gameObject.GetComponent<SpriteRenderer>().sprite.name != name & index < charaNum+1)
        {
            GetComponent<SpriteRenderer>().sprite = array[index];
        }
        else if (index >= charaNum + 1)
        {
            GetComponent<SpriteRenderer>().sprite = array[0];
        }
	}
}
