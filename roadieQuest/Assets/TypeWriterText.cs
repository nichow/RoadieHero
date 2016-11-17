using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterText : MonoBehaviour {

    public Text textBox;
    public string[] text = { "Hey, Travis, you guys are on in 15.", "Yeah, whatever.",
                             "Oh, by the way, tune this guitar before we go up.", "I already did.",
                             "I switched out the strings. They're gold now.", "Gold? That doesn't really—",
                             "It matches my hair, really adds to my image up there, Here you go."};
    public int textDisplay = 0;
	// Use this for initialization
	void Start () {
        StartCoroutine(AnimateText());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //skips the currently displayed text (to be used with a button press) 
    void SkipText ()
    {
        StopAllCoroutines();
        textDisplay++;
        if(textDisplay > text.Length) //as of now this just loops the text
        {
            textDisplay = 0;
        }
        StartCoroutine(AnimateText());
    }

    //does typewriter text
    IEnumerator AnimateText()
    {
        for(int i = 0; i < text[textDisplay].Length + 1; i++)
        {
            //textDisplayed.text = text[textDisplay].Substring(0, i);
            yield return new WaitForSeconds(.2f);
        }
    }
}
