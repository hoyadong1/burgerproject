using System.Collections;
using UnityEngine;

public class FrenchfriesController : MonoBehaviour
{
    private Renderer friesRenderer;
    private bool isCooked = false;
    private bool isBurned = false;

    // 색상 설정
    public Color cookedColor = Color.yellow; // 익은 색상
    public Color burnedColor = Color.black; // 탄 색상
    public float cookTime = 3f; // 익는 데 걸리는 시간
    public float burnTime = 3f; // 탄 상태로 변하기까지의 추가 시간

    void Start()
    {
        friesRenderer = GetComponent<Renderer>();
        StartCoroutine(CookingProcess());
    }

    // 오브젝트가 5초 후 익고, 10초 후 타는 과정을 코루틴으로 관리
    IEnumerator CookingProcess()
    {
        yield return new WaitForSeconds(cookTime);
        friesRenderer.material.color = cookedColor;
        isCooked = true;

        yield return new WaitForSeconds(burnTime);
        if(IsOnTag("Oil")){
            friesRenderer.material.color = burnedColor;
            isBurned = true;
        }

    }

    void OnMouseDown()
    {
        // 익었고 오일 태그 위에 있을 때
        if (isCooked && !isBurned && IsOnTag("Oil"))
        {
            MoveToNewPosition(new Vector3(-5, 1, 0)); // 오일 태그 위에서 익었을 때 이동할 위치
        }
        // 탔고 오일 태그 위에 있을 때
        else if (isBurned && IsOnTag("Oil"))
        {
            Destroy(gameObject); // 오일 태그 위에서 탔을 때 오브젝트 제거
        }
        // 바스켓 태그 위에 있을 때
        else if (IsOnTag("Basket"))
        {
            MoveToNewPosition(new Vector3(-5, -3.5f, 0)); // 바스켓 태그 위에서 이동할 위치
            transform.localScale = new Vector3(0.1f,0.3f,0);
        }
        // 테이블 태그 위에 있을 때
        else if (IsOnTag("Table"))
        {
            Destroy(gameObject); // 테이블 태그 위에서 오브젝트 제거
        }
    }

    // 태그 확인 메서드
    bool IsOnTag(string tag)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (var collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }

    // 새 위치로 이동
    void MoveToNewPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }
}
