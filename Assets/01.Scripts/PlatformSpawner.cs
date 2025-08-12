using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;//에디터상의 프로젝트 뷰애서 할당을 해줄 변수

    public float spawnTimeMin = 0.7f;//생성하는데 걸리는 최소 시간
    public float spawnTimeMax = 1.2f;//생성하는데 걸리는 최대 시간

    public float yMin = -3.5f;//생성된 플랫폼이 위치할 position의 최소 y값
    public float yMax = 1.5f;//생성된 플랫폼이 위치한 position의 최대 y값

    public float xPos = 16f;//생성된 플랫폼이 위치할 position의 x값
    
    float lastSpawnTime;//마지막으로 생성된 시점.
    float spawnTime;


    // Start is called before the first frame update
    void Start()
    {
        lastSpawnTime = Time.time;//게임이 구동이 되고 나서 흐른 시간.
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);

    }

    // Update is called once per frame
    void Update()
    {
        //게임 오버가 되면 진행X
        if (FindObjectOfType<GameManager>().isGameOver == true)
            return;

        if (Time.time >= lastSpawnTime + spawnTime) //마지막으로 생성된 시점+ spawnTime 만큼 더 시간이 흘렀을때
        {
            GameObject platform = Instantiate(platformPrefab);
            //Instantiate함수가 호출이 되는 순간 매개변수로 들어간 오브젝트를 생성시킨다.
            //Instantiate함수가 반환을 해주는 GameObject는 하이어라키(씬)에 새로 생성된 오브젝트의 정보를 반환한다,

            float yPos = Random.Range(yMin, yMax);

            Vector2 setPos = new Vector2(xPos, yPos);

            platform.transform.position = setPos;//생겨난 플랫폼 오브젝트의 위치를 설정하는 부분

            lastSpawnTime = Time.time;
            spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            
            
        }

    }
}
