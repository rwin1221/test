using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMagicBall : MonoBehaviour
{
    GameObject player;
    float timer;
    Transform trans;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.rotation + " " + player.transform.rotation);
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.localPosition += transform.forward * 0.3f;
        if (timer > 5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("check enemy");
        }
    }
}
