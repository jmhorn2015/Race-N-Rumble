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

    void Start()
    {
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
        }
        else if(!SaveState.AvailChara[CharaNum])
        {
            displayer.text = "Not Enough";
        }
    }
}

