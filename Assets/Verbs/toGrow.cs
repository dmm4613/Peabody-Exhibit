﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toGrow : Verb {

    /*
     * The object will grow at a variable rate/multiplier for a duratinon of time.
     * User sets the rate and duration.
     * At the start of this activated verb Conjugate() is called to calculate the target size to grow towards
     */

    //______Variable Declarations_____________________
    public float growMultiplier = 2.0f;
	public float duration = 3.0f;
    //________________________________________________
    public Verb[] triggeredVerbs;

	private float timePassed;
	private Vector3 StartScale;
	private Vector3 FinalScale;

	void Awake () {
		SetAudio();
        Conjugate();
	}

    private void Start()
    {
        if (isActive)
            PlayAudio();
    }

    // Update is called once per frame
    void Update () {
		if(isActive)
		{
            //This will set the scale of the object to a given point between start and final scales
			transform.localScale = Vector3.Lerp(StartScale, FinalScale, timePassed);
			timePassed += Time.deltaTime / duration;

			if(timePassed >= 1.0f)
			{
                EndVerb();
                Activate(triggeredVerbs);
			}
		}
	}

    //overrides the Conjugate() function in the Verb() class.
    override public void Conjugate () {
        /*
         * Takes the private variables of StartScale and FinalScale and sets them both
         * before any transforming occurs on the object.
         */
		StartScale = this.transform.localScale;
		FinalScale = StartScale * growMultiplier;
		timePassed = 0.0f;
        PlayAudio();
	}
}
