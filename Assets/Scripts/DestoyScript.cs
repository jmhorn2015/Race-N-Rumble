using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyScript : MonoBehaviour {

    string spritename;
    public int parentname;
    int flag = 0;
    SaveState.PlayerState playerObject;
	// Update is called once per frame
	void Start()
    {
        spritename = gameObject.name;
        playerObject = SaveState.Players[parentname-1];
        if (playerObject.Attack != spritename)
        {
            //if sprite is not found in savestate then destroy it and its childern
            destroyChildren();
            Destroy(this);
        }
        else
        {
            Debug.Log(playerObject.Attack + spritename);
        }
	}
    public void destroyChildren()
    {
	    foreach (var child in gameObject.GetComponentsInChildren<Transform>())
        {
            Destroy(child.gameObject);
        }
    }

}
