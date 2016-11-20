using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TypeWriterText : MonoBehaviour {

    public Text textBox;
    public Dictionary<int, string> text = new Dictionary<int, string>
    {
            {0, "Hey, Travis, you guys are on in 15."},
            {1, "Yeah, whatever."},
            {1, "Oh, by the way, tune this guitar before we go up."},
            {0, "I already did."},
            {1, "I switched out the strings. They're gold now."},
            {0, "Gold? That doesn't really—"},
            {1, "It matches my hair, really adds to my image up there, Here you go."}
    };
    public int textDisplay = 0;
	// Use this for initialization
	void Start () {
        textBox = GetComponentInChildren<Text>();
        StartCoroutine(AnimateText());
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Submit"))
            SkipText();
	}

    //skips the currently displayed text (to be used with a button press) 
    void SkipText ()
    {
        StopAllCoroutines();
        textDisplay++;
        if(textDisplay > text.Count) //as of now this just loops the text
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
            textBox.text = text[textDisplay].Substring(0, i);
            yield return new WaitForSeconds(.05f);
        }
    }
}
