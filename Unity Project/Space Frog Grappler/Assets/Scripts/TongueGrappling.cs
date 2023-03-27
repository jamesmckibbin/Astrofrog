using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueGrappling : MonoBehaviour
{
    private bool flying = false, outgoing = false, attached = false;
    private Vector3 targetPos, startingPos, attachPoint;

    [SerializeField] private Transform frog;
    [SerializeField] private string[] tonguePassThroughTags; //list of object tags that the tongue will not attach to or bounce off of
    [SerializeField] private float shootSpeed, retractSpeed, maxRange, tongueRange, tongueStrength, velClamp;

    // Start is called before the first frame update
    void Start()
    {
        PlayerInput.FireTongue += Shoot;
        PlayerInput.RetractTongue += Retract;
    }

    // Update is called once per frame
    void Update()
    {
        if (flying)
        {
            UnparentedMove();
        }
    }

    private void FixedUpdate()
    {
        if (attached) //If the player is hooked and isn't already being pulled in with a strong force, pull them towards the center with a force proportional to the distance from the target.
        {
            Vector3 baseForce = Vector3.Normalize(transform.position - frog.transform.position) * tongueStrength;
            float distScale = Mathf.Clamp((Vector2.Distance(transform.position, frog.transform.position) - tongueRange), 0, velClamp);
            if (frog.GetComponent<Rigidbody2D>().velocity.magnitude < velClamp)
                frog.GetComponent<Rigidbody2D>().AddForce(new Vector2(baseForce.x * distScale, baseForce.y * distScale));
        }
        if (transform.parent != null)
        {
            transform.localPosition = new Vector3(0, 0.5f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("I touched a " + collision.gameObject.tag);
        if (outgoing)//Don't attach to anything if it's retracting or just waiting to be fired.
        {
            if (collision.gameObject.CompareTag("Tongueable")) //If the tongue hits a target, mark it as attached to something and not outgoing, attach the hook to the center of the targt, and reset the player's jumps.
            {
                attached = true;
                outgoing = false;
                transform.position = collision.transform.position;
            }
            else if (System.Array.IndexOf(tonguePassThroughTags, collision.gameObject.tag) != -1)
            {
                //do nothing, let the tongue pass through
            }
            else
            {
                outgoing = false;
            }
        }
    }
    
    private void UnparentedMove()
    {
        if (outgoing) //If the hook is flying out, extend at _shootSpeed.
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, shootSpeed * Time.deltaTime);
            if (Vector3.Distance(targetPos, transform.position) <= 0.1) //If tongue has reached max range, start retracting.
            {
                Retract();
            }
        }
        else if (!attached) //If not flying out and not connected to target, retract at _retractSpeed. 
        {
            transform.position = Vector3.MoveTowards(transform.position, frog.transform.position, retractSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, frog.transform.position) <= 0.1) //If close enough to frog, reattach to frog.
            {
                Reattach();
            }
        }
    }
    public void Reattach()
    {
        flying = false;
        transform.SetParent(frog, true);
    }

    private void Shoot()
    {
        Debug.Log("pew");
        flying = true;
        outgoing = true;
        transform.SetParent(null, true); //unparents the tongue end from the frog
        targetPos = transform.position + (maxRange * transform.up); //sets target position to a distance ahead of the curent facing position.
    }

    private void Retract()
    {
        attached = false;
        outgoing = false;
        flying = true;
    }
}
