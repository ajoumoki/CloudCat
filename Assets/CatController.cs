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
        print("고양이 컬리션 충돌"); //고양이 컬리션 충돌 출력
    }

    private void OnTriggerEnter2D(Collider2D collision) //trigger충돌이 일어날 때
    {
        print("고양이 트리거 충돌"); //고양이 트리거 충돌 출력
        SceneManager.LoadScene("ClearScene"); //씬 ClearScene으로 변경
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && this.rigid2D.velocity.y == 0) //만약 y가 0이고, 마우스 왼쪽 버튼을 클릭했을 때
        {
            this.animator.SetTrigger("jump"); //애니메이션 jump 실행
            this.rigid2D.AddForce(transform.up * this.jumpForce); //AddForce값을 jumpForce 곱하기 up 값으로 변경
        }
        int key = 0; //key값을 0으로 설정
        if (Input.acceleration.x > this.threshold) //x값의 기울기가 threshold값보다 크면
        {
        key = 1;  //key값을 1으로 설정
        }
        if(Input.GetKey(KeyCode.RightArrow)) //만일 오른쪽 화살표를 눌렀을 때
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
