using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TwoWayFly : MonoBehaviour
{
    //Each instance of these flies can have their speed and start direction tweaked in the editor.
    [SerializeField] private float movementSpeed, movementAngle;
    private float translatedX, translatedY;
    private Rigidbody2D flyRb;
    SpriteRenderer flySpriteRender;
    public CircleCollider2D col;
    //Uses trigonometrics to translate the speed and angle into two vectors.
    //Wouldn't ya know it? That stuff we were taught in high-school geometry class had real-life applications after all!
    void Start()
    {
        flyRb = GetComponent<Rigidbody2D>();
        flySpriteRender = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();

        translatedX = movementSpeed * Mathf.Cos(movementAngle * Mathf.Deg2Rad);
        translatedY = movementSpeed * Mathf.Sin(movementAngle * Mathf.Deg2Rad);

        flyRb.velocity = new Vector2(translatedX, translatedY);
    }

    //When this fly hits a wall, it'll change directions.
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Tongueable"))
        {
            translatedX *= -1;
            translatedY *= -1;

            flyRb.velocity = new Vector2(translatedX, translatedY);

            if (flyRb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            }
            else if (flyRb.velocity.x < 0)
            {
                transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

            }
        }
    }
}
