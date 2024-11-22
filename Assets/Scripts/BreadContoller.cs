using UnityEngine;

public class MovableObject : MonoBehaviour
{
    // 이동할 x 값 (조정할 값)
    public float xOffset = 3.5f;
    
    // 특정 태그를 가진 오브젝트가 있는지 확인할 반경
    public float detectionRadius = 0.5f;
    private bool isComplete = false;

    void OnMouseDown()
    {
        // 현재 오브젝트가 'Heel' 태그의 오브젝트의 자식인지 확인
        if (transform.parent != null && transform.parent.CompareTag("Heel"))
        {
            if(!isComplete){
                // 부모가 Heel 태그의 오브젝트일 경우, 부모의 x 값 변경
            Vector3 parentPosition = transform.parent.position;
            parentPosition.x += (xOffset*2);
            transform.parent.position = parentPosition;
            Debug.Log("부모 Heel 오브젝트의 x 값이 변경되었습니다.");
            isComplete = true;
            }
        }
        else
        {
            // 자식이 아닌 경우 자신의 x 값 변경 및 새로운 위치에서 'Heel' 오브젝트 찾기
            Vector3 newPosition = transform.position;
            newPosition.x -= xOffset;
            transform.position = newPosition;

            // 이동한 위치에 'Heel' 태그의 오브젝트가 있는지 확인
            Collider2D collider = Physics2D.OverlapCircle(transform.position, detectionRadius);
            if (collider != null && collider.CompareTag("Heel"))
            {
                // 'Heel' 태그의 오브젝트를 부모로 설정
                transform.SetParent(collider.transform);
                Debug.Log("이동한 위치의 Heel 오브젝트가 부모로 설정되었습니다.");
            }
            else
            {
                Debug.Log("이동한 위치에 Heel 태그의 오브젝트가 없습니다.");
            }
        }
    }
}
