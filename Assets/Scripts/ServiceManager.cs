using UnityEngine;

public class ServiceManager : MonoBehaviour
{
    private GameObject selectedPrefab; // 선택된 프리팹을 저장
    public float scaleMultiplier = 1.1f; // 선택 시 커질 비율 (1.1 = 10% 증가)

    // 프리팹이 클릭되었을 때 호출되는 메서드
    public void OnPrefabSelected(GameObject prefab)
    {
        // 기존 선택된 프리팹을 시각적으로 비활성화
        if (selectedPrefab != null)
        {
            DeselectPrefab(selectedPrefab);
        }

        // 새로운 선택된 프리팹을 설정 및 시각적 효과
        selectedPrefab = prefab;
        SelectPrefab(selectedPrefab);
    }

    // 프리팹 선택 시 시각적 효과를 적용하는 메서드
    private void SelectPrefab(GameObject prefab)
    {
        // 크기를 살짝 키워서 선택된 것처럼 표시
        prefab.transform.localScale *= scaleMultiplier;
    }

    // 선택 해제 시 시각 효과를 되돌리는 메서드
    private void DeselectPrefab(GameObject prefab)
    {
        // 크기를 원래대로 되돌림
        prefab.transform.localScale /= scaleMultiplier;
    }
}
