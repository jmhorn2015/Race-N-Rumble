using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script Writer: Navya with edits from Jenna

public class CharacterNavigation : MonoBehaviour {
    bool indexLock = false;
    int index = 1;
    int saveIndex = 0;
    int selectedIndex = 1;
    float xoffset = 4.25f;
    public KeyCode right;
    public KeyCode left;
    public KeyCode select;
    bool isConfirm = false;
    public string PName;
	// Use this for initialization
	void Start () {
        PName = gameObject.name;
        SaveState.PlayerScore = new Dictionary<string, int>();
    }
	public int GetIndex()
    {
        return index;
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(right) & !indexLock)
        {
            if (index < SaveState.maxCharaUnlocked)
            {
                do
                {
                    index++;
                    Vector2 position = transform.position;
                    position.x += xoffset;
                    transform.position = position;
                    selectedIndex = index;
                }
                while (!SaveState.AvailChara[index]);
            }
        }
        if (Input.GetKeyDown(left) & !indexLock)
        {
            if (index >=2)
            {
                do
                {
                    index--;
                    Vector2 position = transform.position;
                    position.x -= xoffset;
                    transform.position = position;
                    selectedIndex = index;
                }
                while (!SaveState.AvailChara[index]);
            }
        }
        if (Input.GetKeyDown(select)) // Select edited by Jenna Horn
        {
            if (!isConfirm)
            {
                switch (index-1)
                {
                    case 0:
                        SaveState.PlayerSaveState(PName, "Fighter", "Push");
                        break;
                    case 1:
                        SaveState.PlayerSaveState(PName, "Dragon", "");
                        break;
                    case 2:
                        SaveState.PlayerSaveState(PName, "Alien", "fire");
                        break;
                    case 3:
                        SaveState.PlayerSaveState(PName, "Demon", "fire");
                        break;
                    case 4:
                        SaveState.PlayerSaveState(PName, "Mage", "fire");
                        break;
                    default:
                        SaveState.PlayerSaveState(PName, "Normal", "Push");
                        break;
                }
                indexLock = true;
                SaveState.Players.TrimExcess();
                saveIndex = SaveState.Players.Capacity - 1;
                isConfirm = true;
                Debug.Log(SaveState.Players.Capacity + "\n" + SaveState.PlayerScore.Count);
            }
            else
            {
                indexLock = false;
                SaveState.Players.RemoveAt(saveIndex);
                SaveState.PlayerScore.Remove(PName);
                isConfirm = false;
                Debug.Log(SaveState.Players.Capacity + "\n" + SaveState.PlayerScore.Count);
            }
        }
	}
}
