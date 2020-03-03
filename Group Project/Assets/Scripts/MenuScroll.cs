using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScroll : MonoBehaviour
{

    float scrollSpeed = 50f;
    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, 715);
        transform.position = startPos + Vector3.right * newPos;
    }
}
