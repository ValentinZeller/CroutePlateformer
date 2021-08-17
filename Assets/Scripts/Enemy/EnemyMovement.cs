using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 newPos;

    [SerializeField]
    private float distance;

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool IsBackForth;

    

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        newPos = startPos;
        endPos = new Vector3(startPos.x + distance,startPos.y,startPos.z);
    }

    void OnDrawGizmosSelected()
    {
        Vector3 start = transform.position;
        Vector3 end = new Vector3(start.x + distance, start.y, start.z);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(start, end);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(IsBackForth)
        //Patrol movement
        {
            if (Vector3.Distance(transform.position, endPos) < 0.2f)
            {
                startPos = endPos;
                endPos = newPos;
                newPos = startPos;
            }

            transform.position = Vector3.MoveTowards(transform.position, endPos, speed * Time.deltaTime);
        } else
        //Bullet-horizontal movement
        {
            transform.position += new Vector3(Time.deltaTime * speed, 0);
        }
    }
}
