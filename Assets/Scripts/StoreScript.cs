using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreScript : MonoBehaviour {
    public int CharaNum;
    private bool UpdateTurnOff = false;
    private Text displayer;
    public int CharacterCost;
    public Button yourButton;
    AudioClip locked;
    AudioClip unlocked;

    void Start()
    {
        locked = Resources.Load<AudioClip>("Audio/SE/BuyFail") as AudioClip;
        unlocked = Resources.Load<AudioClip>("Audio/SE/BuySuccess") as AudioClip;
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
        displayer = this.GetComponentsInChildren<Text>()[0];
        if (SaveState.AvailChara[CharaNum] & !UpdateTurnOff)
        {
            displayer.text = "Unlocked";
            UpdateTurnOff = true;
        }
        else
        {
            string writer = "Cost: " + CharacterCost.ToString();
            displayer.text = writer;
        }
    }
    void Update()
    {
        if (SaveState.AvailChara[CharaNum] & !UpdateTurnOff)
        {
            displayer.text = "Unlocked";
            UpdateTurnOff = true;
        }
    }
	void OnClick()
    {
        if (CharacterCost <= SaveState.MoneyScore & !SaveState.AvailChara[CharaNum])
        {
            SaveState.MoneyScore -= CharacterCost;
            SaveState.AvailChara[CharaNum] = true;
            if (CharaNum > SaveState.maxCharaUnlocked)
            {
                SaveState.maxCharaUnlocked = CharaNum;
            }
            AudioSource.PlayClipAtPoint(unlocked, new Vector3(0, 0, 0));
        }
        else if(!SaveState.AvailChara[CharaNum])
        {
            displayer.text = "Not Enough";
            AudioSource.PlayClipAtPoint(locked, new Vector3(0, 0, 0));
        }
    }
}

