﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationIdleAndPlay : MonoBehaviour {
    public Animator anim;

    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }


    
}