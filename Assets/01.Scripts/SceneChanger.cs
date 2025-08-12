using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // 전환할 씬의 이름을 Inspector에서 설정
    [SerializeField]
    private string targetSceneName;

    /// <summary>
    /// 버튼 클릭 시 이 함수를 호출하세요.
    /// </summary>
    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(targetSceneName))
        {
            SceneManager.LoadScene(targetSceneName);
        }
        else
        {
            Debug.LogWarning("SceneChanger: targetSceneName이 비어 있습니다!");
        }
    }
}