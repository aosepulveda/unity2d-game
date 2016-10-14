using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    // The Player's speed
    public float speed = 10.0f;
    //Game boundaries
    private float leftWall = -4f;
    private float rightWall = 4f;

    //Reference to the Animator
    private Animator anim;
    private SpriteRenderer renderer;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        // Get the horizontal axis that by default is bound to the arrow keys
        // The value is in the range -1 to 1
        // Make it move per seconds instead of frames
        float translation = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        //Change direction if needed
        if (translation > 0)
        {
            renderer.flipX = false;
        }
        else if (translation < 0)
        {
            renderer.flipX = true;
        }

        // Switching between Idle and Walk states in the animator
        if (translation != 0)
        {
            anim.SetFloat("PlayerSpeed", speed);
        }
        else
        {
            anim.SetFloat("PlayerSpeed", 0);
        }

        // Switching between Jump and Walk animation
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("Jump", !(anim.GetBool("Jump")));
        }

        // Move along the object's x-axis within the floor bounds
        if (transform.position.x + translation < rightWall && transform.position.x + translation > leftWall)
            transform.Translate(translation, 0, 0);
    }
}