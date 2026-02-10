using UnityEngine;

public class RigidBody2 : MonoBehaviour
{
    Vector3 velocity;
    BoxCollider col;
    
    public  float gravity;
    public float skin;

    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        float castDistance = Mathf.Max(skin * 2f, Mathf.Abs(velocity.y) * Time.fixedDeltaTime);
        Vector3 origin = transform.position + col.center - Vector3.up * (col.size.y / 2f - skin);
        
        //raycast downwards to check for ground
        RaycastHit hit;
        if (Physics.Raycast(origin, Vector3.down, out hit, castDistance)){
            velocity.y = 0f;
            transform.position = new Vector3(
                transform.position.x,
                hit.point.y + col.size.y / 2f,
                transform.position.z
            );
        }
        else
        {
            velocity.y -= gravity * Time.fixedDeltaTime;
            //Debug.Log(velocity);
        }

        transform.position += velocity * Time.fixedDeltaTime;
    }
}