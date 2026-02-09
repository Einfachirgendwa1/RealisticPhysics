using UnityEngine;

public class RigidBody2 : MonoBehaviour {
    
    private Vector3 velocity = new Vector3(0,0,0);
    
    public int masse;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;    
    }
}
