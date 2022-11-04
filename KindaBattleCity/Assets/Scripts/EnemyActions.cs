using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public static Vector3 enemyPosition;
    public static Vector3 enemyAngle;
    public GameObject enemy;
    public GameObject destroyedEnemy;
    public Transform shot;
    private bool toShoot = false;


    private void OnCollisionEnter(Collision collision)
    {
        print(1);
        enemyPosition = transform.position;

        enemyAngle -= new Vector3(0, 90, 0);
        
        if (collision.collider.tag == "Destroy")
        {
            GameObject bedrocks = Instantiate(destroyedEnemy, enemyPosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyAngle = new Vector3(0, 90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        enemyPosition = transform.position;

        GetComponent<Transform>().eulerAngles = enemyAngle;
        GetComponent<Rigidbody>().velocity = transform.forward * 2.5f;
    }
}
