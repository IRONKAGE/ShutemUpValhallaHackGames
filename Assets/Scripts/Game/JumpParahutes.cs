﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parashute : MonoBehaviour
{
    public Transform parashuteSpawn;
    public Rigidbody ParashuteMan;
    public float parashuteSpeed;

    // Update is called once per frame
    void Update() {
        if(Input.GetButtonDown("Parashute")) {
            Rigidbody ParashuteManRigidbody;
            ParashuteManRigidbody = Instantiate(ParashuteMan, parashuteSpawn.position, parashuteSpawn.rotation) as Rigidbody;
            ParashuteManRigidbody.AddForce(parashuteSpawn.forward * parashuteSpeed);
        }
        
    }
}