using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class guitarTuning : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip[] AudioClips;
    public Color originalColor;
    public Color newColor;
    public float[] counters;
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
        

        if (Input.GetButtonDown("1String"))
        {
            counters[0] += .5f;
            pegs[5].GetComponent<Animator>().SetTrigger("turn");
        }
        else if (Input.GetButtonDown("2String"))
        {
            counters[1] += .5f;
            pegs[4].GetComponent<Animator>().SetTrigger("turn");            
        }
        else if (Input.GetButtonDown("3String"))
        {
            counters[2] += .5f;
            pegs[3].GetComponent<Animator>().SetTrigger("turn");
        }
        else if (Input.GetButtonDown("4String"))
        {
            counters[3] += .5f;
            pegs[2].GetComponent<Animator>().SetTrigger("turn");
        }
        else if (Input.GetButtonDown("5String"))
        {
            counters[4] += .5f;
            pegs[1].GetComponent<Animator>().SetTrigger("turn");
        }
        else if (Input.GetButtonDown("6String"))
        {
            counters[5] += .5f;
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
                this.enabled = false; 
            }
        }

        for (int i = 0; i < counters.Length; i++)
        {
            if (counters[i] >= .0035f)
            {
                counters[i] -= .0035f;
            }
                

            if (counters[i] > 4f)
            {
                sprites[i + 1].color = originalColor;
            }
            else if (counters[i] >= 2f)
            {
                sprites[i + 1].color = newColor;
            }
            else
            {
                sprites[i + 1].color = originalColor;
            }

        }

    }

    /* Called when the player enters the 
     * tuning minigame */
    public void tune()
    {
        Debug.Log("called");
        Audio = GetComponent<AudioSource>();

    }

    bool isTuned(float[] counters)
    {
        foreach (var counter in counters)
        {
            if (!(counter >= 2f && counter <= 4f))
                return false;
        }
        return true;
    }
}
