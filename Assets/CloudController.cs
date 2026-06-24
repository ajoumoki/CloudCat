using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision  //이 게임오브젝트가 컬리션 충돌을 했을 때
    {
        print("구름 컬리션 충돌");
    }

    private void OnTriggerEnter2D(Collider2D collision) //이 게임오브젝트가 트리거 충돌을 했을 때
    {
        print("구름 트리거 충돌");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
