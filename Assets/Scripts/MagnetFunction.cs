using UnityEngine;
using System.Collections;

public class MagnetFunction : MonoBehaviour
{

    public float magnetPower;
    public GameObject Owner;
    public GameObject Prey;
    private LineRenderer line;

    // Use this for initialization
    void Start()
    {
        Prey = gameObject;
        var lineObj = EffectSpawner.instance.GetEffect("magnetLine");
        lineObj.transform.SetParent(transform);
        lineObj.transform.localPosition = Vector3.zero;
        lineObj.SetActive(true);
        line = lineObj.GetComponent<LineRenderer>();

        //PreyRb = Prey.GetComponent<Rigidbody2D>();
        Destroy(this, 0.5f);
    }

    void Update()
    {
        line.SetPosition(1,Owner.transform.position - transform.position);
        line.transform.rotation = Quaternion.identity;
        line.material.SetTextureOffset("_MainTex",Vector2.right * Random.Range(0f,1f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Prey.GetComponent<Rigidbody2D>().AddForce((Owner.transform.position - Prey.transform.position).normalized * magnetPower);
        Owner.GetComponent<Rigidbody2D>().AddForce((Prey.transform.position - Owner.transform.position).normalized * magnetPower);
    }

    void OnDestroy()
    {
        line.transform.parent = EffectSpawner.instance.transform;
        line.gameObject.SetActive(false);
    }
}
