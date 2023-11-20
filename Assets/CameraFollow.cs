using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    Vector3 position;
    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        position.x = player.transform.position.x;
        position.y = player.transform.position.y;
        transform.position = position;
    }
}
