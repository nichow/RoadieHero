using UnityEngine;
using System.Collections;

public class cameraMovement : MonoBehaviour {

    Vector3 destination;
    public float speed;
    float startTime;
    float journeyLength;

	// Use this for initialization
	void Start () {
        destination = new Vector3(0, 0, -10);
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, destination);
    }

    // Update is called once per frame
    void Update () {
        float distance = (Time.time - startTime) * speed;
        float fracJourney = distance / journeyLength;
        transform.position = Vector3.Lerp(transform.position, destination, fracJourney);
    }
}
