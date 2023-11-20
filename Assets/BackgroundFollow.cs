using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 position;
    private SpriteRenderer spr;
    void Start()
    {
        position = transform.position;
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x - transform.position.x > spr.sprite.bounds.size.x)
        {
            position.x += 3 * spr.sprite.bounds.size.x;
            transform.position = position;
        }
    }
}
