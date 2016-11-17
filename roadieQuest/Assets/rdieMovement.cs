using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class rdieMovement : MonoBehaviour
{

    float speed = 0;
    Animator anim;


    // Use this for initialization
    void Start()
    {
        speed = .05f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            var xDirection = Input.GetAxis("Horizontal");
            if (xDirection > 0)
            {
                transform.Translate(Vector2.right * speed);
                if(!Input.GetButton("Vertical"))
                    anim.Play("RoadieRightMove");
            }
            else if (xDirection < 0)
            {
                transform.Translate(Vector2.left * speed);
                if (!Input.GetButton("Vertical"))
                    anim.Play("RoadieLeftMove");
            }
        }
        if (Input.GetButton("Vertical"))
        {
            var yDirection = Input.GetAxis("Vertical");
            if (yDirection > 0)
            {
                transform.Translate(Vector2.up * speed);
                anim.Play("RoadieMoveUp");
            }
            else if (yDirection < 0)
            {
                transform.Translate(Vector2.down * speed);
                anim.Play("RoadieMoveDown");
            }
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger");
        if (other.tag.Contains("NPC"))
        {
            Debug.Log("will it load?");
            SceneManager.LoadScene("dialogue");
        }
        if(other.tag.Contains("Background"))
        {
            Debug.Log("Screen transition, stat!");
            var bgScript = other.GetComponent<Background>();
            if (transform.position.x > 0)
            {
                bgScript.BackgroundChange(1);
                
            }
            else
            {
                bgScript.BackgroundChange(0);
            }
        }

    }
}
