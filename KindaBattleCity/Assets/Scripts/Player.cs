using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Vector3 playerPosition;
    public Transform shot;
    private bool toShoot = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.position;

        if (Input.GetKey("up"))
        {
            GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().velocity = transform.forward * 2.5f;
        }

        else
            if (Input.GetKey("down"))
            {
                GetComponent<Transform>().eulerAngles = new Vector3(0, 180, 0);
                GetComponent<Rigidbody>().velocity = transform.forward * 2.5f;
            }

        else
            if (Input.GetKey("right"))
            {
                GetComponent<Transform>().eulerAngles = new Vector3(0, 90, 0);
                GetComponent<Rigidbody>().velocity = transform.forward * 2.5f;
            }

        else
            if (Input.GetKey("left"))
            {
            GetComponent<Transform>().eulerAngles = new Vector3(0, -90, 0);
            GetComponent<Rigidbody>().velocity = transform.forward * 2.5f;
            }

        else
        {
            GetComponent<Rigidbody>().velocity = transform.forward * 0;
            GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        }

        if (Input.GetKey("space") && toShoot == false)
        {
            toShoot = true;
            Transform bulletTf = Instantiate(shot, new Vector3(transform.position.x, 0.93f, transform.position.z), transform.rotation);
            bulletTf.gameObject.GetComponent<Rigidbody>().velocity = transform.forward;
            StartCoroutine(restartShot());
        }

        IEnumerator restartShot()
        {
            yield return new WaitForSeconds(1.5f);
            toShoot = false;
        }

    }
}
