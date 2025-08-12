using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    float speed = 0.02f;

    float width;

    GameObject[] obstacles;


    // Start is called before the first frame update
    void Start()
    {
        //width = GetComponent<BoxCollider2D>().size.x;

        BoxCollider2D col = GetComponent<BoxCollider2D>();

        width = col.size.x;

        int count = transform.childCount;//현재 오브젝트의 자식 오브젝트 갯수

        obstacles = new GameObject[count];

        for(int i=0;i<count;i++)
        {
            obstacles[i] = transform.GetChild(i).gameObject;

            if (Random.Range(0, 3) >= 1) //3분의 2확률
            {
                obstacles[i].SetActive(false);//오브젝트를 비활성화 시키는 부분.
            }
        }



        
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버가 되면 진행X
        if (FindObjectOfType<GameManager>().isGameOver == true)
            return;


        transform.Translate(Vector2.left * speed);

        if(transform.position.x<= -width*3)
        {
            Destroy(gameObject);
        }
    }
}
