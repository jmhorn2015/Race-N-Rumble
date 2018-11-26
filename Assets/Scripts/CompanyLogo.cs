using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompanyLogo : MonoBehaviour {
    bool inFade = false;
	// Use this for initialization
	void Start () {
        float num = 1 - Time.deltaTime;
        Invoke("toMain", 1.8f*num);
        Invoke("fade", num);
	}

    void Update()
    {
        if (inFade == true)
        {
            Color current = gameObject.GetComponent<SpriteRenderer>().color;
            if (current.a != 0)
            {
                current.a -= .02f;
            }
            gameObject.GetComponent<SpriteRenderer>().color = current;
        }
    }

    void fade()
    {
        inFade = true;
    }
	
	void toMain()
    {
        SceneManager.LoadScene("Title Menu");
    }
}
