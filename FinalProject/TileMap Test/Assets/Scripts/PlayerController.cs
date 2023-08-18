using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("right")) gameObject.transform.position += new Vector3(1, 0);
        if (Input.GetKeyDown("left")) gameObject.transform.position += new Vector3(-1, 0);
        if (Input.GetKeyDown("up")) gameObject.transform.position += new Vector3(0, 1);
        if (Input.GetKeyDown("down")) gameObject.transform.position += new Vector3(0, -1);

    }
}
