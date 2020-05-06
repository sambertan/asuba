using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freccia : MonoBehaviour
{
    public bool blinking=true;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        if (!blinking)
        {
            animator.enabled = false;
        }
    }
}
