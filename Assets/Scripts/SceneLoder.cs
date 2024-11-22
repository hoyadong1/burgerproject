using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderOnClick : MonoBehaviour
{
    // 로드할 씬 이름
    public string sceneName;

    void OnMouseDown()
    {
        // 씬 로드
        SceneManager.LoadScene(sceneName);
    }
}
