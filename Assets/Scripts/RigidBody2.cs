using UnityEngine;

public class RigidBody2 : MonoBehaviour {
    public float gravity;
    public float skin;

    public BoxCollider col;
    private Vector3 velocity;

    private void FixedUpdate() {
        float castDistance = Mathf.Max(skin * 2f, Mathf.Abs(velocity.y) * Time.fixedDeltaTime);

        Vector3 origin = transform.position + col.center - Vector3.up * (col.size.y / 2f - skin);

        if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, castDistance)) {
            velocity.y = 0f;
            float yPosition = hit.point.y + col.size.y / 2f;
            transform.position = new Vector3(transform.position.x, yPosition, transform.position.z);
        } else {
            velocity.y -= gravity * Time.fixedDeltaTime;
        }

        transform.position += velocity * Time.fixedDeltaTime;
    }

    public void AddForce(Vector3 force) => velocity += force;
}