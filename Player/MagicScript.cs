using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicScript : MonoBehaviour
{
    public GameObject magicMissile;
    private bool sk1Check;

    // Use this for initialization
    void Start()
    {
        sk1Check = false;
    }

    // Update is called once per frame
    void Update()
    {
        shootMagic();
        magicMissile.transform.position = transform.position + new Vector3(0f, 0f, 5f);
    }

    void shootMagic()
    {
        if (Input.GetButtonDown("Skill1") && sk1Check == false)
        {
            StartCoroutine("MakeMagic");
        }
    }

    IEnumerator MakeMagic()
    {
        sk1Check = true;
        Instantiate(magicMissile, transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);
        sk1Check = false;
    }
}
