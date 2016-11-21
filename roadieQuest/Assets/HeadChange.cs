using UnityEngine;
using System.Collections;

public class HeadChange : MonoBehaviour {

    public Sprite roadieHead;
    public Sprite travisHead;
    int[] personTalking = { 0, 1, 1, 0, 1, 0, 1 };
    int personTracker;

    // Use this for initialization
    void Start () {
        StartCoroutine(changeHead());
        personTracker = 0;
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(changeHead());
        if (Input.GetButtonDown("Submit"))
            {
                
                personTracker++;
                if (personTracker >= personTalking.Length)
                {
                    StopAllCoroutines();
                    enabled = false;
                }
            }  
    }

    IEnumerator changeHead()
    {
        if (personTalking[personTracker] == 0)
        {
            GetComponent<UnityEngine.UI.Image>().sprite = roadieHead;
        }
        else
        {
            GetComponent<UnityEngine.UI.Image>().sprite = travisHead;
        }
        yield return null;
    }

}
