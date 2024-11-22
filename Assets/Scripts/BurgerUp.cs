using UnityEngine;

public class BurgerUp : MonoBehaviour
{
    // 탐색할 반경
    public float detectionRadius = 0.5f;

    // 탐색할 위치
    public Vector3 checkPosition = new Vector3(3, 1, 0);

    void OnMouseDown()
    {
        // 지정된 위치에 있는 모든 콜라이더 감지
        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkPosition, detectionRadius);

        // 'Heel' 태그의 오브젝트가 있는지 확인하고 제거
        bool heelFound = false;
        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Heel"))
            {
                Destroy(collider.gameObject);
                heelFound = true;
                Debug.Log("Heel 태그의 오브젝트가 제거되었습니다.");
            }
        }

        if (!heelFound)
        {
            Debug.Log("지정된 위치에 Heel 태그의 오브젝트가 없습니다.");
        }
    }
}
