using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    float width;
    public float offsetX;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        width = collider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버가 되면 진행X
        if (FindObjectOfType<GameManager>().isGameOver == true)
            return;

        transform.Translate(Vector2.left * speed);

        if(transform.position.x <= -width)
        {
            Vector3 setPos = new Vector3(width * 2f + offsetX, 0 , 0);
            transform.position = transform.position + setPos;
        }


    }
}
