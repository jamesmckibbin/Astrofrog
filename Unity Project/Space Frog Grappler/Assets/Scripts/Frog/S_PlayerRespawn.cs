using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerRespawn : MonoBehaviour
{
    private Vector3 checkpointPosition;
    [SerializeField] private Rigidbody2D frog;
    // Start is called before the first frame update
    void Start()
    {
        checkpointPosition = frog.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Checkpoint"))
        {
            checkpointPosition = collision.transform.position;
        }
        if(collision.CompareTag("Respawn"))
        {
            frog.transform.position = checkpointPosition;
            frog.velocity = Vector2.zero;
            FindObjectOfType<S_OxygenMeter>().RemoveOxygen(50);

        }
    }
}
