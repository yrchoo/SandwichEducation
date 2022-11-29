using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cshDestroy : MonoBehaviour
{
    public float destroyTime = 3f;
    float time = 0f;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > destroyTime)
        {
            time = 0f;
            gameObject.SetActive(false);
        }
    }
}
