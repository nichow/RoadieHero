using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tuningDialogue : MonoBehaviour {

    int diaCounter;
    Text dialogue;
    Color32 travisColor = new Color32(255, 99, 143, 255);
    Color32 roadieColor = new Color32(243, 255, 165, 255);

    // Use this for initialization
    void Start () {
        dialogue = GetComponent<Text>();
        dialogue.text = "Hey, roadie.";
        dialogue.alignment = TextAnchor.LowerRight;
        dialogue.color = travisColor;
        diaCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        dialogue = GetComponent<Text>();
        if (Input.GetButtonDown("Submit"))
        {
            diaCounter++;
            switch (diaCounter)
            {
                case 1:
                    dialogue.alignment = TextAnchor.LowerLeft;
                    dialogue.text = "I tuned all of your guitars, Travis.";
                    dialogue.color = roadieColor;
                    break;
                case 2:
                    dialogue.alignment = TextAnchor.LowerRight;
                    dialogue.text = "Yeah, I know. I want to switch out the strings on one of them.";
                    dialogue.color = travisColor;
                    break;
                case 3:
                    dialogue.alignment = TextAnchor.LowerLeft;
                    dialogue.text = "...Why?";
                    dialogue.color = roadieColor;
                    break;
                case 4:
                    dialogue.alignment = TextAnchor.LowerRight;
                    dialogue.text = "Because I want GOLD strings on this one.";
                    dialogue.color = travisColor;
                    break;
                case 5:
                    dialogue.text = "It's going to be so sexy, and it matches my hair.";
                    break;
                case 6:
                    dialogue.alignment = TextAnchor.LowerLeft;
                    dialogue.text = "The tone is going to be much softer... is that what you want?";
                    dialogue.color = roadieColor;
                    break;
                case 7:
                    dialogue.alignment = TextAnchor.LowerRight;
                    dialogue.text = "Hmm? Oh yeah. Whatever. Just do it.";
                    dialogue.color = travisColor;
                    break;
                case 8:
                    dialogue.alignment = TextAnchor.LowerLeft;
                    dialogue.text = "....";
                    dialogue.color = roadieColor;
                    break;
                case 9:
                    SceneManager.LoadScene("tuning");
                    break;
            }
        }
	}
}
