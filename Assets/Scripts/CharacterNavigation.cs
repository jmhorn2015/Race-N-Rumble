using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script Writer: Navya with edits from Jenna

public class CharacterNavigation : MonoBehaviour {
    bool indexLock = false;
    int index = 1;
    int saveIndex = 0;
    int selectedIndex = 1;
    float checker = 0f;
    float xoffset = 4.25f;
    float yoffset = 1.2f;
    bool isConfirm = false;
    bool isRight = false;
    bool isLeft = false;
    string PName;
    public int charaNum;
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
        if(checker != InputManager.MainHorizontal(charaNum))
        {
            if (InputManager.MainHorizontal(charaNum) > 0)
            {
                isRight = true;
                isLeft = false;
            }
            else if(InputManager.MainHorizontal(charaNum) < 0)
            {
                isLeft = true;
                isRight = false;
            }
            else
            {
                isLeft = false;
                isRight = false;
            }
        }
        else
        {
            isLeft = false;
            isRight = false;
        }
        checker = InputManager.MainHorizontal(charaNum);
        if (isRight & !indexLock)
        {
            if (index < SaveState.maxCharaUnlocked)
            {
                do
                {
                    index++;
                    Vector2 position = transform.position;
                    position.x += xoffset;
                    switch (index)
                    {
                        case 5:
                            position.x -= xoffset * 4;
                            position.y -= yoffset;
                            break;
                        case 9:
                            position.x -= xoffset * 4;
                            position.y -= yoffset;
                            break;
                        default:
                            break;
                    }
                    transform.position = position;
                    selectedIndex = index;
                }
                while (!SaveState.AvailChara[index]);
            }
        }
        if (isLeft & !indexLock)
        {
            if (index >=2)
            {
                do
                {
                    index--;
                    Vector2 position = transform.position;
                    position.x -= xoffset;
                    switch (index)
                    {
                        case 4:
                            position.x += xoffset * 4;
                            position.y += yoffset;
                            break;
                        case 8:
                            position.x += xoffset * 4;
                            position.y += yoffset;
                            break;
                        default:
                            break;
                    }
                    transform.position = position;
                    selectedIndex = index;
                }
                while (!SaveState.AvailChara[index]);
            }
        }
        if (InputManager.Power(charaNum)) // Select edited by Jenna Horn
        {
            Debug.Log(SaveState.howManyPlayers);
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
                    case 5:
                        SaveState.PlayerSaveState(PName, "Elf", "fire");
                        break;
                    case 6:
                        SaveState.PlayerSaveState(PName, "Priest", "fire");
                        break;
                    case 7:
                        SaveState.PlayerSaveState(PName, "Veteran", "fire");
                        break;
                    case 8:
                        SaveState.PlayerSaveState(PName, "Ninja", "fire");
                        break;
                    case 9:
                        SaveState.PlayerSaveState(PName, "Boss Lady", "fire");
                        break;
                    case 10:
                        SaveState.PlayerSaveState(PName, "Unicorn", "fire");
                        break;
                    case 11:
                        SaveState.PlayerSaveState(PName, "Queen", "fire");
                        SaveState.isQueen = true;
                        break;
                    default:
                        Debug.Log("player not found");
                        break;
                }
                indexLock = true;
                SaveState.Players.TrimExcess();
                saveIndex = SaveState.Players.Capacity - 1;
                isConfirm = true;
            }
            else
            {
                indexLock = false;
                SaveState.Players.RemoveAt(saveIndex);
                SaveState.PlayerScore.Remove(PName);
                isConfirm = false;
                SaveState.isQueen = false;
                Debug.Log(SaveState.Players.Capacity + "\n" + SaveState.PlayerScore.Count);
            }
        }
	}
}
