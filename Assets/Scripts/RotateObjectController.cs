using UnityEngine;
using UnityEngine.UI;

public class RotateObjectsController : MonoBehaviour
{
    public GameObject[] objectsToRotate; // 활성화할 오브젝트 3개를 배열로 받음
    private int currentIndex = 0; // 현재 활성화된 오브젝트의 인덱스
    public Button rotateButton; // 캔버스에 있는 버튼

    void Start()
    {
        // 버튼 클릭 이벤트에 메서드 연결
        if (rotateButton != null)
        {
            rotateButton.onClick.AddListener(RotateObjects);
        }

        // 초기화 시 첫 번째 오브젝트만 활성화하고 나머지는 비활성화
        UpdateActiveObject();
    }

    void RotateObjects()
    {
        // 클릭 시 다음 오브젝트로 이동
        currentIndex = (currentIndex + 1) % objectsToRotate.Length;
        UpdateActiveObject();
    }

    // 현재 인덱스에 해당하는 오브젝트만 활성화하는 메서드
    void UpdateActiveObject()
    {
        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            objectsToRotate[i].SetActive(i == currentIndex);
        }
    }
}
