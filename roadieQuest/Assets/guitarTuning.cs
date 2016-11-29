using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class guitarTuning : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip[] String1, String2, String3, String4, String5, String6;
    public float[] counters = { 0, 0, 0, 0, 0, 0 };
    public int[] audioCounters = { 0, 0, 0, 0, 0, 0 };
    public GameObject[] pegs;
    public SpriteRenderer[] sprites;
    public Sprite[] spriteRotation;
    public GameObject youRock;
    public ParticleSystem explosion;
    public bool crRunning;


    // Use this for initialization
    void Start()
    {
        InitAllCoroutines();
        Camera.main.GetComponent<cameraMovement>();
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetButtonDown("6String"))
        {
            tuneString(0, String6);
        }
        else if (Input.GetButtonDown("5String"))
        {
            tuneString(1, String5);
        }
        else if (Input.GetButtonDown("4String"))
        {
            tuneString(2, String4);
        }
        else if (Input.GetButtonDown("3String"))
        {
            tuneString(3, String3);
        }
        else if (Input.GetButtonDown("2String"))
        {
            tuneString(4, String2);
        }
        else if (Input.GetButtonDown("1String"))
        {
            tuneString(5, String1);
        }

        if (Input.GetButtonDown("Submit"))
        {
            if (isTuned(counters))
            {
                for (int i = 0; i < counters.Length; i++)
                    counters[i] = counters[i];

                if (Audio.isPlaying)
                    Audio.Stop();

                explosion.Play();
                youRock.GetComponent<SpriteRenderer>().enabled = true;
                Audio.Play();
                enabled = false; 
            }
        }

        for (int i = 0; i < counters.Length; i++)
        {
            if (counters[i] > 2f && counters[i] < 4f)
            {
                audioCounters[i] = 4;
                sprites[i].sprite = spriteRotation[1];
                StopAllCoroutines();
                crRunning = false;
            }
            else if (counters[i] <= 2f)
            {
                if(!crRunning)
                    InitAllCoroutines();
                
                if (counters[i] >= 1.5f)
                    audioCounters[i] = 3;
                else if (counters[i] >= 1f)
                    audioCounters[i] = 2;
                else if (counters[i] >= 0.5f)
                    audioCounters[i] = 1;
                else
                    audioCounters[i] = 0;

                sprites[i].sprite = spriteRotation[0];
            }
            else if(counters[i] >= 4f)
            {
                if (!crRunning)
                    InitAllCoroutines();

                audioCounters[i] = 4;
                sprites[i].sprite = spriteRotation[2];
            }

            if (counters[i] > .005f)
                counters[i] -= .005f;
        }

    }

    void tuneString(int counter, AudioClip[] String)
    {
        if (Audio.isPlaying)
            Audio.Stop();

        Audio.PlayOneShot(String[audioCounters[counter]]);
        counters[counter] += .5f;
        pegs[counter].GetComponent<Animator>().SetTrigger("turn");
    }

    bool isTuned(float[] counters)
    {
        foreach (var counter in counters)
        {
            if (!(counter > 2f && counter < 4f))
                return false;
        }
        return true;
    }

    void InitAllCoroutines()
    {
        foreach (var sprite in sprites)
        {
            StartCoroutine(SpriteFlicker(sprite));
            crRunning = true;
        }
    }


    IEnumerator SpriteFlicker(SpriteRenderer thisSprite)
    {
        while (true)
        {
            thisSprite.enabled = false;
            yield return new WaitForSeconds(.5f);
            thisSprite.enabled = true;
            yield return new WaitForSeconds(.5f);
        }
        
    }
}
