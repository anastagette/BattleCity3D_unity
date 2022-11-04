using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBedrock : MonoBehaviour
{
    public GameObject destroyableBedrockVoxel;
    public GameObject destroyedBedrockVoxel;
    public int health;

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
        if (collision.collider.tag == "Destroy")
        {
            health -= 1;

            if (health == 0)
            {
                GameObject bedrocks = Instantiate(destroyedBedrockVoxel, destroyableBedrockVoxel.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

    }
}
