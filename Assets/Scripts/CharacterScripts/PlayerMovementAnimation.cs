using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPress = Input.GetKey("w");

        // Player uses W key to move forward
        if (forwardPress)
        {
            // Set animator "isWalking" bool to true
            animator.SetBool("isWalking", true);
        }

        // Player is NOT pressing W key
        if(!forwardPress)
        {
            animator.SetBool("isWalking", false);
        }
    }
}