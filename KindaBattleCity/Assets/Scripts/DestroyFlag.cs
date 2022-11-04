using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFlag : MonoBehaviour
{
    public GameObject flag;
    public GameObject destroyedFlag;

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
            GameObject bedrocks = Instantiate(destroyedFlag, flag.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
