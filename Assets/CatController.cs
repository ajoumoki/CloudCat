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
        key = 1; //key값을 1로 설정
        }
        if(Input.acceleration.x < -threshold) //x값이 threshold값보다 작으면
        {
            key = -1; //key값을 -1로 설정
        }
        if(Input.GetKey(KeyCode.LeftArrow)) //왼쪽 화살표 키를 눌렀을 때
        {
            key = -1; //key값을 -1로 설정
        }
        float speedx = Mathf.Abs(this.rigid2D.velocity.x); //speedx값을 velocity값의 절댓값으로 설정
        if(speedx < this.maxWalkSpeed) //speedx값이 maxWalkSpeed값보다 작으면
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce); //transform의 right값과 walkForce값과 key값의 곱만큼 힘주기
        }
        if (key != 0) //만약 key가 0이 아니면
        {
            transform.localScale = new Vector3(key, 1, 1); //transform의 localScale값을 key, 1, 1로 설정
        }
        this.animator.speed = speedx / 2.0f; //애미네이터의 speed를 speedx를 2로 나눈 값으로 설정하기
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

}
