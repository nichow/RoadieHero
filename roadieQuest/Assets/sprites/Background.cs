using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public Sprite[] backgrounds;
    SpriteRenderer sr;
    int tracker;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void BackgroundChange (int direction)
    {
        sr = GetComponent<SpriteRenderer>();
        if (direction == 1)
            sr.sprite = backgrounds[++tracker];
    }
}
