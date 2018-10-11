using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class userTracking : MonoBehaviour
{
    GameObject player;
    GameObject gate;

    Transform monster;
    Transform playertsf;

    Animator ani;
    NavMeshAgent nav;

    public GameObject explosion;

    public enum monState { idle, trace };
    public monState curstate = monState.idle;

    bool follow = false;

    public float traceDist = 25.0f;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playertsf = GameObject.FindWithTag("Player").GetComponent<Transform>();
        // 위치값 가져오기
        //monster = this.gameObject.GetComponent<Transform>();
        //gate = GameObject.FindGameObjectWithTag("gate");

        monster = GetComponent<Transform>();
        ani = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();

    }
    void Start()
    {
        StartCoroutine(this.State());
        StartCoroutine(this.Action());
    }
    // Update is called once per frame
    void Update()
    {
        // nav.SetDestination(player.transform.position);

    }
    IEnumerator State()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            // 지연 시간
            float dist = Vector3.Distance(playertsf.position, monster.position);
            if (dist > traceDist)
            {
                curstate = monState.idle;
                Debug.Log("check in" + dist + " " + traceDist);
            }
            else
            {
                curstate = monState.trace;
                Debug.Log("check out" + dist + " " + traceDist);
                //nav.Stop();
            }
        }
    }
    IEnumerator Action()
    {
        while (true)
        {
            switch (curstate)
            {
                case monState.idle:
                    nav.Stop();
                    break;
                case monState.trace:
                    nav.SetDestination(player.transform.position);
                    nav.Resume();
                    break;
            }
            yield return null;
        }
    }

    void InitPosition()
    {
        transform.position = new Vector3(0f, 0f, 0f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            InitPosition();
        }
    }
}


