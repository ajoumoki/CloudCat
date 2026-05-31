using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("cat"); //게임오브젝트 cat 찾기
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = this.player.transform.position; //playerPos값을 cat의 위치로 설정
        transform.position = new Vector3(
            transform.position.x,playerPos.y,transform.position.z);
    }
}
