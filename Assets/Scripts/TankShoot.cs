﻿using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour {

    public GameObject shootPos;
    public GameObject bullet;
    float shootTimer = 0.2f;
    public float timer = 0f;
    float curTime = 0f;
    bool keyHold = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            keyHold = true;
        }
        //Debug.Log(timer);

        if (keyHold == true)
        {
            StartCoroutine(Timer());
        }

        if (Input.GetButtonUp("Fire1"))
        {
           //Debug.Log(timer);
            if (timer > shootTimer)
            {
                Debug.Log("Shoot");
                Instantiate(bullet, shootPos.transform);
            }
            timer = 0f;
            keyHold = false;

        }
    }

    IEnumerator Timer()
    {
       
            timer += Time.deltaTime;
        
        //yield return null;
        yield break;
    }


}