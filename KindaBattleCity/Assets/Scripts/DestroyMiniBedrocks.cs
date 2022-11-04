using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMiniBedrocks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObject(gameObject, 2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DestroyObject(GameObject obj, float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(obj);
    }
}
