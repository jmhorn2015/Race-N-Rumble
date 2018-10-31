using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script Writer: Rachel Alexander
//Add to the background asset within each map

public class scr_LiveScoring_v2 : MonoBehaviour
{
    //set up parameters to be customized
    public int label_width = 200;  //these are for the text labels that display the player scores
    public int label_height = 30;

    public int img_width = 100;  //these are for the images that will be used for the players
    public int img_height = 100;

    private int left_margin = 30; //x dimension of left-hand labels
    private int top_margin = 10; //y dimension of top labels
    private int right_margin = 0; //x dimension of right-hand labels
    private int bottom_margin = 0;  //y dimension of bottom labels

    public int score_fontSize = 26;  //these are for the text that displays the player name and score
    public Color score_fontColor = Color.black;

    void OnGUI()
    {
        right_margin = (int)(gameObject.GetComponent<Camera>().scaledPixelWidth) - 130;
        bottom_margin = (int)(gameObject.GetComponent<Camera>().scaledPixelHeight) - 80;
        //create the style for the score 
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = score_fontSize;
        myStyle.normal.textColor = score_fontColor;

        GUIStyle imagePlaceholderStyle = new GUIStyle();
        //add stylings for the player images here


        //setting up rectangles for the player images
        Rect image1 = new Rect(left_margin, top_margin, img_width, img_height);
        Rect image2 = new Rect(right_margin-30, top_margin, img_width, img_height);
        Rect image3 = new Rect(left_margin, bottom_margin - (img_height + 20), img_width, img_height);
        Rect image4 = new Rect(right_margin - 30, bottom_margin - (img_height + 20), img_width, img_height);

        //add player images to the GUI
        GUI.Label(image1, "", imagePlaceholderStyle);
        GUI.Label(image2, "", imagePlaceholderStyle);
        GUI.Label(image3, "", imagePlaceholderStyle);
        GUI.Label(image4, "", imagePlaceholderStyle);


        //add player scores to the gui
        GUI.Label(new Rect(left_margin, top_margin + img_height + 20, label_width, label_height), "" + SaveState.Players[0].Name + "\n    " + SaveState.PlayerScore[SaveState.Players[0].Name], myStyle);
        GUI.Label(new Rect(right_margin, top_margin + img_height + 20, label_width, label_height), "" + SaveState.Players[1].Name + "\n    " + SaveState.PlayerScore[SaveState.Players[1].Name], myStyle);
        GUI.Label(new Rect(left_margin, bottom_margin, label_width, label_height), "" + SaveState.Players[2].Name + "\n    " + SaveState.PlayerScore[SaveState.Players[2].Name], myStyle);
        GUI.Label(new Rect(right_margin, bottom_margin, label_width, label_height), "" + SaveState.Players[3].Name + "\n    " + SaveState.PlayerScore[SaveState.Players[3].Name], myStyle);
    }
}


