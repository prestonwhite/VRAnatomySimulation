using UnityEngine;
using System.Collections;

public class animation_controller : MonoBehaviour {

    //public Animation anim;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            return;
        }
        animator.speed = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.A))
            animator.speed = 0;

        if (Input.GetKey(KeyCode.S))
            animator.speed = 0.5f;

        if (Input.GetKey(KeyCode.D))
            animator.speed = 1;
    }
}
