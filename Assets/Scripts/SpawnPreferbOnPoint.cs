using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnPoints : MonoBehaviour
{
    public GameObject prefabToSpawn; // 생성할 프리팹
    public List<Transform> spawnPoints; // 빈 오브젝트들의 위치를 담은 리스트
    public float checkRadius = 0.5f; // 콜라이더 감지 반경
    private int currentIndex = 0; // 현재 체크할 위치의 인덱스

    void OnMouseDown()
    {
        // 현재 인덱스부터 리스트의 끝까지 순회하여 빈 공간을 찾음
        for (int i = currentIndex; i < spawnPoints.Count; i++)
        {
            // 해당 위치에 콜라이더가 없을 때 프리팹을 생성
            if (IsSpaceEmpty(spawnPoints[i].position))
            {
                Instantiate(prefabToSpawn, spawnPoints[i].position, Quaternion.identity);
                currentIndex = (i + 1) % spawnPoints.Count; // 다음 인덱스 설정
                return; // 하나만 생성하고 종료
            }
        }

        // 만약 리스트의 끝까지 찾았는데 빈 공간이 없다면, 처음부터 다시 탐색
        currentIndex = 0;
    }

    // 지정된 위치에 콜라이더가 없는지 확인하는 메서드 (2D 환경)
    bool IsSpaceEmpty(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, checkRadius);
        return colliders.Length == 0; // 감지된 콜라이더가 없으면 true 반환
    }
}
