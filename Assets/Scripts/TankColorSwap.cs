using UnityEngine;
using System.Collections;

public class TankColorSwap : MonoBehaviour
{
    SpriteRenderer sp;

    // Use this for initialization
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("ColorChange");
            // sp.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }

    }
}
