using UnityEngine;
using System.Collections;

public class travisMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        GameObject roadie = GameObject.Find("charRdie");
        transform.position = Vector3.MoveTowards(transform.position, roadie.transform.position, .1f);

    }
}
