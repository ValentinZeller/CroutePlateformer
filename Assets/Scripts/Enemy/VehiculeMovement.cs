using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehiculeMovement : MonoBehaviour
{
    BoxCollider2D bx;
    SpriteRenderer sprite;

    [SerializeField]
    private float finalScale;

    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        bx = GetComponent<BoxCollider2D>();
        bx.enabled = false;

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x < finalScale)
        {
            transform.localScale += new Vector3(1 * speed,1 * speed,0);
            sprite.color = Color.Lerp(sprite.color, Color.red, Mathf.PingPong(Time.time, speed)); ;
        } else if (transform.localScale.x >= finalScale)
        {
            sprite.color = Color.red;
            bx.enabled = true;
            Destroy(gameObject, 2);
        }
    }
}
