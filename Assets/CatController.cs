using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigid2D;
    Animator animator;
    float jumpForce = 680.0f; //jumpForce값 680으로 설정
    float walkForce = 30.0f; //walkforce값 30으로 설정
    float maxWalkSpeed = 2.0f; //maxWalkSpeed값 2로 설정
    float threshold = 0.2f; // threshold값 0.2로 설정
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>(); //Rigidbody2D컴포넌트 불러오기
        this.animator = GetComponent<Animator>(); //Animator컴포넌트 불러오기
    }

    private void OnCollisionEnter2D(Collision2D collision) //collision충돌이 일어날 때
    {
        print("고양이 컬리션 충돌");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("고양이 트리거 충돌");
        SceneManager.LoadScene("ClearScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0)
        {
            this.animator.SetTrigger("jump");
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }
        int key = 0;
        if (Input.acceleration.x > this.threshold)
        {
        key = 1; 
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
        key = 1; 
        }
        if(Input.acceleration.x < -threshold)
        {
            key = -1;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if(speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }
        this.animator.speed = speedx / 2.0f;
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

}
