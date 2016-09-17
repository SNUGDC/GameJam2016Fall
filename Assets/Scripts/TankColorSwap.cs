using UnityEngine;
using System.Collections;

public class TankColorSwap : MonoBehaviour
{

    //SpriteRenderer spBody;
    //SpriteRenderer spHead;
    SpriteRenderer[] sp;

    // Use this for initialization
    void Start()
    {
        //spBody = GetComponent<SpriteRenderer>();
        //spHead = GetComponentInChildren<SpriteRenderer>();
        sp = GetComponentsInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("ColorChange");

            //spBody.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
            sp[0].color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
            if(sp[1] != null)
            {
                sp[1].color = sp[0].color;
            }
            //new Color(spBody.color.r, spBody.color.g, spBody.color.b, spBody.color.a);
        }

    }
}
