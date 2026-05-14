using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("备抚 拿府记 面倒");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("备抚 飘府芭 面倒");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
