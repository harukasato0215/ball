using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    //タグの登録をできるようにした
    public string targetTag;
    public bool IsHolding { get; set; }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            IsHolding = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            IsHolding = false;

        }
    }
    void OnTriggerStay(Collider other)
    {

        Rigidbody r = other.gameObject.GetComponent<Rigidbody>();

        //ベクトルの計算
        Vector3 direction = other.gameObject.transform.position - transform.position;
        //均等な力で押している方向成分
        direction.Normalize();

        if (other.gameObject.tag == targetTag)//落としたいボールが来たとき
        {
            //スピードを落としている
            r.velocity *= 0.9f;
            r.AddForce(direction * -20.0f, ForceMode.Acceleration);
        }
        else
        {
            r.AddForce(direction * 80.0f, ForceMode.Acceleration);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
