using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class guitarTuning : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip[] String1, String2, String3, String4, String5, String6;
    public Color originalColor;
    public Color newColor;
    public int[] counters = { 0, 0, 0, 0, 0, 0 };
    public GameObject[] pegs;
    public GameObject youRock;
    public ParticleSystem explosion;


    // Use this for initialization
    void Start()
    {
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (var sprite in sprites)
        {
            sprite.color = originalColor;
        }
        Camera.main.GetComponent<cameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        var sprites = GetComponentsInChildren<SpriteRenderer>();
        

        if (Input.GetButtonDown("1String") && counters[0] < 5)
        {
            if (Audio.isPlaying)
                Audio.Stop();

            Audio.PlayOneShot(String1[counters[0]]);
            counters[0] += 1;
            pegs[5].GetComponent<Animator>().StopPlayback();
            pegs[5].GetComponent<Animator>().SetTrigger("turn");
        }
        else if (Input.GetButtonDown("2String") && counters[1] < 5)
        {
            if (Audio.isPlaying)
                Audio.Stop();
            

            Audio.PlayOneShot(String1[counters[1]]);
            counters[1] += 1;
            pegs[4].GetComponent<Animator>().SetTrigger("turn");            
        }
        else if (Input.GetButtonDown("3String") && counters[2] < 5)
        {
            if (Audio.isPlaying)
                Audio.Stop();

            Audio.PlayOneShot(String1[counters[2]]);
            counters[2] += 1;
            pegs[3].GetComponent<Animator>().SetTrigger("turn");
        }
        else if (Input.GetButtonDown("4String") && counters[3] < 5)
        {
            if (Audio.isPlaying)
                Audio.Stop();

            Audio.PlayOneShot(String1[counters[3]]);
            counters[3] += 1;
            pegs[2].GetComponent<Animator>().SetTrigger("turn");
        }
        else if (Input.GetButtonDown("5String") && counters[4] < 5)
        {
            if (Audio.isPlaying)
                Audio.Stop();

            Audio.PlayOneShot(String1[counters[4]]);
            counters[4] += 1;
            pegs[1].GetComponent<Animator>().SetTrigger("turn");
        }
        else if (Input.GetButtonDown("6String") && counters[5] < 5)
        {
            if (Audio.isPlaying)
                Audio.Stop();

            Audio.PlayOneShot(String1[counters[5]]);
            counters[5] += 1;
            pegs[0].GetComponent<Animator>().SetTrigger("turn");
        }

        if (Input.GetButtonDown("Submit"))
        {
            Debug.Log("checking...");
            if (isTuned(counters))
            {
                Debug.Log("Got it, familia");
                for (int i = 0; i < counters.Length; i++)
                    counters[i] = counters[i];
                explosion.Play();
                youRock.GetComponent<SpriteRenderer>().enabled = true;
                Audio.Play();
                enabled = false; 
            }
        }

        for (int i = 0; i < counters.Length; i++)
        {
            if (counters[i] == 5)
            {
                sprites[i + 1].color = newColor;
            }
        }

    }

    bool isTuned(int[] counters)
    {
        foreach (var counter in counters)
        {
            if (!(counter == 5))
                return false;
        }
        return true;
    }
}
