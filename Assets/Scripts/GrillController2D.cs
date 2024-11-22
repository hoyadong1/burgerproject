using UnityEngine;

public class GrillController2D : MonoBehaviour
{
    public GameObject pattyPrefab;      // 패티 프리팹
    private Camera mainCamera;
    public float minDistance = 10f;    // 패티 간 최소 거리 설정
    public LayerMask pattyLayer;        // 패티가 있는 레이어 설정

    void Start()
    {
        mainCamera = Camera.main; // 메인 카메라 참조
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 또는 터치
        {
            PlacePattyOnClick();
        }
    }

    void PlacePattyOnClick()
    {
        // 클릭 위치를 월드 좌표로 변환
        Vector2 clickPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(clickPosition, Vector2.zero);

        // 클릭 위치가 그릴의 콜라이더에 속하는지 확인
        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            // 클릭 위치 주변에 패티가 있는지 검사
            if (!IsPattyNearby(clickPosition))
            {
                Instantiate(pattyPrefab, clickPosition, Quaternion.identity); // 새로운 패티 생성
            }
            else
            {
                Debug.Log("패티가 이미 가까운 위치에 있습니다. 다른 위치를 클릭하세요.");
            }
        }
    }

    // 클릭 위치 주변에 패티가 있는지 확인하는 함수
    bool IsPattyNearby(Vector2 position)
    {
        // OverlapCircle로 클릭 위치 주변의 패티 Collider 검사
        Collider2D hitCollider = Physics2D.OverlapCircle(position, minDistance, pattyLayer);
        return hitCollider != null; // 패티가 있으면 true, 없으면 false
    }
}
