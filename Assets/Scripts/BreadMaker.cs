using UnityEngine;

public class SpawnPrefabOnSpriteClick : MonoBehaviour
{
    // 첫 번째 프리팹과 생성 위치들
    public GameObject prefabToSpawn1;
    private Vector3[] spawnLocations1 = { new Vector3(-4, 1, 0), new Vector3(-4, -1, 0), new Vector3(-4, -3, 0) };
    private int prefabCount1 = 0;
    
    // 두 번째 프리팹과 생성 위치들
    public GameObject prefabToSpawn2;
    private Vector3[] spawnLocations2 = { new Vector3(-0.5f, 1, 0), new Vector3(-0.5f, -1, 0), new Vector3(-0.5f, -3, 0) };
    private int prefabCount2 = 0;

    void OnMouseDown()
    {
        // 첫 번째 프리팹 생성
        if (prefabCount1 < 3 && prefabToSpawn1 != null)
        {
            Instantiate(prefabToSpawn1, spawnLocations1[prefabCount1], Quaternion.identity);
            prefabCount1++;
        }
        else if (prefabCount1 >= 3)
        {
            Debug.Log("첫 번째 프리팹의 최대 생성 개수에 도달했습니다.");
        }

        // 두 번째 프리팹 생성
        if (prefabCount2 < 3 && prefabToSpawn2 != null)
        {
            Instantiate(prefabToSpawn2, spawnLocations2[prefabCount2], Quaternion.identity);
            prefabCount2++;
        }
        else if (prefabCount2 >= 3)
        {
            Debug.Log("두 번째 프리팹의 최대 생성 개수에 도달했습니다.");
        }
    }
}
