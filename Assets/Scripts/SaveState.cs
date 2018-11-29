using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

// Script Writers(SaveState): Nivedita Vattipalli and Navya Doddapaneni with Edits from Jenna Horn
// Script Writers(GameCntrl and ): Anudeep Maturi and Navya Doddapaneni with Edits from Jenna Horn

public class SaveState : MonoBehaviour
{
    GameObject alpha;
    public static List<string> MapList = new List<string>();
    public static List<PlayerState> Players = new List<PlayerState>();
    public static Dictionary<string, int> PlayerScore = new Dictionary<string, int>();
    public static bool[] AvailChara = new bool[13];
    public static int[] PowerUpLeft = new int[4];
    public static int MoneyScore = 0;
    public static int MapCounter = 0;
    public static int maxCharaUnlocked = 1;
    public static int howManyPlayers = 4;
    public static bool isQueen = false;
    public static bool isPause = false;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        GameCntrl.LoadFile();
        if(StartGame.MapMax == 0)
        {
            StartGame.MapMax = 10;
        }
        if(AvailChara.Length != 13)
        {
            AvailChara = new bool[13];
        }
        if (howManyPlayers < 2)
        {
            howManyPlayers = 4;
        }
        AvailChara[1] = true;
    }
    void OnDestroy()
    {
       GameCntrl.SavetoFile();
    }
    
    public static void PlayerSaveState(string PName, string PAttack, string PIconpath)
    {

        PlayerState player = new PlayerState(PName, PAttack, PIconpath);
        Players.Add(player);
        PlayerScore[PName] = 0;

    }

    //calculates the highest score and assign that as money score
    public static string DisplayScoreofPlayer() //edited by Jenna Horn
    {
        MapCounter = 0;
        int originalCount = PlayerScore.Count;
        string results = "";
        for (int x = 0; x < originalCount; x++)
        {
            int NextScore = 0;
            string NextScoreName = null;
            foreach (KeyValuePair<string, int> ps in PlayerScore)
            {
                Debug.Log(ps.Value);
                if (ps.Value > NextScore)
                {
                    NextScore = ps.Value;
                    NextScoreName = ps.Key;
                }
                else if (ps.Value == 0 && NextScore == 0)
                {
                    NextScore = ps.Value;
                    NextScoreName = ps.Key;
                }
            }
            results += NextScoreName + "     " + NextScore + " pts\n";
            Debug.Log(NextScoreName);
            PlayerScore.Remove(NextScoreName);
            if (x == 0)
            {
                MoneyScore += NextScore;
            }
        }
        Players.Clear();
        PlayerScore.Clear();
        MapList.Clear();
        return results;
    }

    //datastructure of each player
    [Serializable]
    public struct PlayerState
    {
        public string Name, Attack, ImagePath;

        public PlayerState(string PName, string PAttack, string PIconpath)
        {
            Name = PName;
            Attack = PAttack;
            ImagePath = PIconpath;
        }
    }
}
[Serializable]
class GameSaveData
{
    public List<string> MapList = new List<string>();
    public List<SaveState.PlayerState> Players = new List<SaveState.PlayerState>();
    public Dictionary<string, int> PlayerScore = new Dictionary<string, int>();
    public int MoneyScore = 0;
    public int MapCounter = 0;
    public bool[] AvailChara = new bool[13];
    public int[] PowerUpLeft = new int[4];
    public int maxCharaUnlocked = 1;
    public int howManyPlayers = 4;
    public int MapMax = 10;

}

public class GameCntrl
{
    public static void SavetoFile()
    {
        BinaryFormatter form = new BinaryFormatter();
        FileStream fs;
        if (!File.Exists(Application.persistentDataPath + "/SaveState.dat"))
        {
            fs = File.Create(Application.persistentDataPath + "/SaveState.dat");
        }
        else
        {
            fs = File.Open(Application.persistentDataPath + "/SaveState.dat", FileMode.Open);
        }
        GameSaveData stuff = new GameSaveData();
        stuff.MapList = SaveState.MapList;
        stuff.Players = SaveState.Players;
        stuff.PlayerScore = SaveState.PlayerScore;
        stuff.MoneyScore = SaveState.MoneyScore;
        stuff.MapCounter = SaveState.MapCounter;
        stuff.AvailChara = SaveState.AvailChara;
        stuff.PowerUpLeft = SaveState.PowerUpLeft;
        stuff.maxCharaUnlocked = SaveState.maxCharaUnlocked;
        stuff.MapMax = StartGame.MapMax;
        stuff.howManyPlayers = SaveState.howManyPlayers;
        form.Serialize(fs, stuff);
        fs.Close();
    }
    public static void LoadFile()
    {
        if(File.Exists(Application.persistentDataPath + "/SaveState.dat"))
        {
            BinaryFormatter form = new BinaryFormatter();
            FileStream fs = File.Open(Application.persistentDataPath + "/SaveState.dat", FileMode.Open);
            GameSaveData stuff;
            try
            {
                stuff = (GameSaveData)form.Deserialize(fs);
                SaveState.MapList = stuff.MapList;
                SaveState.Players = stuff.Players;
                SaveState.PlayerScore = stuff.PlayerScore;
                SaveState.MoneyScore = stuff.MoneyScore;
                SaveState.MapCounter = stuff.MapCounter;
                SaveState.AvailChara = stuff.AvailChara;
                SaveState.PowerUpLeft = stuff.PowerUpLeft;
                SaveState.maxCharaUnlocked = stuff.maxCharaUnlocked;
                StartGame.MapMax = stuff.MapMax;
                SaveState.howManyPlayers = stuff.howManyPlayers;
            }
            catch(Exception e)
            {
                Debug.Log("Deserialization error");
            }
            if (SaveState.MapList != null)
            {
                ButtonManager1.isContinue = true;
            }
            fs.Close();
            SaveState.AvailChara[1] = true;
        }
        else
        {
            Debug.Log("file not found");
        }
    }
}


