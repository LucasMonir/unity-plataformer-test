using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.transform.position.x - transform.position.x > 10)
            Destroy(this.gameObject);
    }
}
