using System.Collections;
using UnityEngine;

public class DrinkButtonController : MonoBehaviour
{
    public GameObject targetObject; // 3초간 활성화할 오브젝트
    public Color cupNewColor = Color.blue; // 변경할 Cup의 색상
    private bool isActivated = false; // 활성화 상태 확인용 변수

    void Start()
    {
        // 시작할 때 targetObject를 비활성화
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        // 클릭되었을 때 아래에 Cup이 있는지 확인
        GameObject cup = GetCupBelow();
        if (cup != null)
        {
            StartCoroutine(ActivateObjectAndChangeColor(cup));
        }
    }

    // 아래에 있는 Cup 오브젝트를 Raycast로 감지하는 메서드
    GameObject GetCupBelow()
    {
        int layerMask = LayerMask.GetMask("CupLayer"); // "CupLayer" 레이어만 감지
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 5f, layerMask);

        if (hit.collider != null && hit.collider.CompareTag("Cup"))
        {
            return hit.collider.gameObject; // 아래에 있는 Cup 오브젝트 반환
        }
        return null;
    }

    // 특정 오브젝트를 3초간 활성화하고, 3초 후에 Cup의 색상을 변경하는 코루틴
    IEnumerator ActivateObjectAndChangeColor(GameObject cup)
    {
        if (isActivated) yield break; // 이미 활성화된 경우 중복 실행 방지
        isActivated = true;

        // targetObject 활성화
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }

        // 3초 대기
        yield return new WaitForSeconds(3f);

        // Cup 색상 변경
        Renderer cupRenderer = cup.GetComponent<Renderer>();
        if (cupRenderer != null)
        {
            cupRenderer.material.color = cupNewColor;
        }

        // targetObject 비활성화
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }

        isActivated = false; // 다시 활성화 가능하도록 설정
    }
}
