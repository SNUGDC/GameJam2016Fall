﻿using UnityEngine;
using System.Collections;

public class TankShoot : MonoBehaviour {

    public GameObject shootPos;
    public GameObject bullet;
    public int shootNum;
    public int curShootNum;
    public float shootInterval;
    public float shootTimer;
    public float timer = 0f;
    public KeyCode keyCode;
    public float bulletSpeed;
    float curTime = 0f;
    bool keyHold = false;

	// Use this for initialization
	void Start () {
        keyCode = GetComponent<Tank>().key;
        StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keyCode))
        {
            keyHold = true;
        }
        //Debug.Log(timer);

        if (Input.GetKeyUp(keyCode))
        {
            //Debug.Log(timer);
            StartCoroutine(Shoot());
            
        }
    }

    IEnumerator Shoot()
    {
        if (timer > shootTimer)
        {
            curShootNum = shootNum;
            while (curShootNum > 0)
            {
                Debug.Log("Shoot");
                GameObject Bullet = Instantiate(bullet, shootPos.transform.position, Quaternion.identity) as GameObject;
                Bullet.transform.rotation = shootPos.transform.rotation;
                // transform.up is green axis
                Bullet.GetComponent<Rigidbody2D>().velocity = shootPos.transform.up * bulletSpeed;
                yield return StartCoroutine(shootIntervalTimer());
                curShootNum--;
                Debug.Log(curShootNum);
                //Debug.Break();
            }

        }
        else
        {
            Debug.Log("Cannot shoot because time is not enough. " + timer);
        }
        timer = 0;
        keyHold = false;
        yield break;
    }

    IEnumerator Timer()
    {
        while (true)
        {
            if (keyHold)
            {
                timer += Time.deltaTime;
            }
            yield return null;
        }
    }

    IEnumerator shootIntervalTimer()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(shootInterval);
        yield break;
    }
}
