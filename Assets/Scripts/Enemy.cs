using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const string LEFT = "left";
    const string RIGHT = "Right";
    
    [SerializeField]
    private Transform castPos;

    [SerializeField]
    private float baseCastDist;

    private string facingDirection;

    private Vector3 baseScale;
    
    Rigidbody2D rigidbody2D;

    private float moveSpeed = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void FixedUpdate()
    {
        float vX = moveSpeed;

        if (facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }
        
        rigidbody2D.velocity = new Vector2(vX, rigidbody2D.velocity.y);

        if (IsHittingWall())
        {
            if (facingDirection == LEFT)
            {
                ChangeFacingDirection(RIGHT);
            }
            else if(facingDirection == RIGHT)
            {
                ChangeFacingDirection(LEFT);
            }
        }
    }

    void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;

        if (newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;

        facingDirection = newDirection;
    }
    
    bool IsHittingWall()
    {
        bool val = false;

        float castDist = baseCastDist;

        if (facingDirection == LEFT)
        {
            castDist = -baseCastDist;
        }

        Vector3 targetPos = castPos.position;

        targetPos.x += castDist;

        if (Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Terrain")))
        {
            val = true;
        }
        

        return val;
    }
}
