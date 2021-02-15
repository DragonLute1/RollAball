using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPBumperScript : MonoBehaviour
{
    public Rigidbody Player;
    public float BumperForce = 100f;
    public PPPlayerControllerScript velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            Player.AddForce(Quaternion.Euler(0, 180, 0) * Player.velocity * BumperForce);
        }
    }
}
