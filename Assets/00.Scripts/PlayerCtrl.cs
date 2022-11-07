using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float jumpPower = 5f;

    Rigidbody2D rigidbody;
    Animator animator;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버가 되면 진행X
        if (FindObjectOfType<GameManager>().isGameOver == true)
            return;

        if (Input.GetButtonDown("Fire1"))
        {
            rigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            //상대방충돌체 기준으로 위쪽에서 충돌이 되었는가
            //collision.contacts 충돌 지점에 대한 정보들의 배열
            //collision.contacts[0].normal 충돌지점 기준의 정방향 벡터
            if(collision.contacts[0].normal.y >= 0.7f)
            {
                isGrounded = true;
                animator.SetBool("IsGrounded", true);
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "Platform")
        {
            isGrounded = false;
            animator.SetBool("IsGrounded", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //게임 오버가 되면 진행X
        if (FindObjectOfType<GameManager>().isGameOver == true)
            return;


        if (collision.tag=="Obstacle")
        {
            animator.SetTrigger("Die");


            //게임오버

            //1번 방식
            GameManager gm = FindObjectOfType<GameManager>();//하이어라키(현재씬)에서 해당 컴포넌트를 찾아줌.*FindObjectOfType 중요
            gm.GameOver();

            ////2번 방식
            //GameObject gmObject = GameObject.Find("GameManvger"); //활성화가 된 오브젝트만 찾아주는 Find 함수. 비활성화되어있는 오브젝트를 찾을시 Null값을 리턴함.
            //GameManager gm = gmObject.GetComponent<GameManager>();
            //gm.GameOver();


        }


    }


}
