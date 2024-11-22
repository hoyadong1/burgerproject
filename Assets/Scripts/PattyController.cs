using UnityEngine;

public class PattyController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;        // 패티의 Sprite Renderer
    public Color cookedColor = new Color(1f,0.5f,0.2f); // 익은 패티 색상
    public Color burntColor = Color.black;       // 탄 패티 색상
    public float blinkInterval = 0.5f;           // 깜박거리는 간격 (초)
    public float blinkAlpha = 0.5f;              // 깜박거릴 때 투명도 (0 = 완전 투명, 1 = 완전 불투명)

    private float creationTime;                  // 패티가 생성된 시간을 기록
    private bool isBlinking = false;             // 깜박거림 여부
    private bool isFlipped = false;              // 패티가 뒤집혔는지 여부
    private bool isBurnt = false;                // 패티가 탄 상태인지 여부
    private Color originalColor;                 // 패티의 원래 색상

    void Start()
    {
        // 패티 생성 시각을 저장하고 원래 색상 저장
        creationTime = Time.time;
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // 패티가 생성된 후 10초가 지나면 패티가 탄 상태로 변경
        if (!isBurnt && Time.time - creationTime >= 10f)
        {
            Debug.Log("패티가 타기 시작합니다.");
            isBurnt = true;
            StopBlinking();
            spriteRenderer.color = burntColor;
        }

        if(!isBurnt && Time.time - creationTime >= 5f){
            StartBlinking();
        }
    }

    // 깜박거림 시작
    void StartBlinking()
    {
        if (!isBlinking)
        {
            Debug.Log("패티가 깜박이기 시작합니다.");
            isBlinking = true;
            StartCoroutine(Blink());
        }
    }

    // 깜박거리는 코루틴 (투명도 조절)
    private System.Collections.IEnumerator Blink()
    {
        while (isBlinking)
        {

            if(isFlipped) {
                spriteRenderer.color = new Color(
                cookedColor.r,
                cookedColor.g,
                cookedColor.b,
                blinkAlpha // 설정한 투명도 값으로 변경
            );
            } else {
                spriteRenderer.color = new Color(
                originalColor.r,
                originalColor.g,
                originalColor.b,
                blinkAlpha // 설정한 투명도 값으로 변경
            );
            }

            yield return new WaitForSeconds(blinkInterval);

            if(isFlipped){
                spriteRenderer.color = cookedColor;
            } else{
                spriteRenderer.color = originalColor;
            }

            yield return new WaitForSeconds(blinkInterval);
        }
    }

    // 깜박임을 멈추는 함수
    private void StopBlinking()
    {
        Debug.Log("깜박거림이 멈췄습니다.");
        isBlinking = false;
    }

    // 패티가 클릭되었을 때 호출되는 함수
    void OnMouseDown()
    {
        // 탄 상태에서는 패티를 제거
        if (isBurnt)
        {
            RemovePatty();
            return;
        }

        // 생고기 또는 익은 상태에서 패티를 클릭했을 때
        if (!isFlipped && isBlinking)
        {
            StopBlinking();    // 깜박거림을 멈추고 패티를 뒤집습니다.
            FlipPatty();
        }

        // 뒤집힌 상태에서 다시 깜박이고 있을 때 패티 제거
        if (isFlipped && isBlinking)
        {
            StopBlinking();
            RemovePatty();
        }
    }

    // 패티 뒤집기 (익은 색으로 변경)
    private void FlipPatty()
    {
        Debug.Log("패티가 뒤집혔습니다.");
        isFlipped = true;
        spriteRenderer.color = cookedColor;   // 익은 상태의 색상으로 변경
        creationTime = Time.time;             // 타이머를 초기화하여 다시 1분 후에 깜박이도록 설정
        isBlinking = false;
    }

    // 패티 제거
private void RemovePatty()
{
    Debug.Log("패티가 제거 요청되었습니다.");

    // 패티를 안 보이게 설정
    spriteRenderer.enabled = false;

    // 0.1초 후에 패티 삭제
    Invoke("DeletePatty", 0.1f);
}

private void DeletePatty()
{
    Debug.Log("패티가 제거되었습니다.");
    Destroy(gameObject);  // 패티 오브젝트를 삭제
}

}
