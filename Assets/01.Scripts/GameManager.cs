using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public GameObject gameOverUI;//에디터상에서 값을 넣어줄 변수
    
    public void GameOver()//게임오버가 됐을때 호출될 함수
    {
        isGameOver = true;

        gameOverUI.SetActive(true);//활성화 시키기

    }

}
