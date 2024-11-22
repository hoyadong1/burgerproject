using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // 생성할 프리팹
    public GameObject prefabToSpawn;
    
    // 프리팹의 생성 위치들
    public Vector3[] spawnLocations = { new Vector3(-6 , -1.5f, 0), new Vector3(-2, -1.5f, 0), new Vector3(2, -1.5f, 0) };
    
    
    // 현재 생성된 프리팹 수
    private int prefabCount = 0;

    void OnMouseDown()
    {
        // 프리팹의 최대 생성 수(3개)를 확인
        if (prefabCount < 3)
        {
        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnLocations[prefabCount], prefabToSpawn.transform.rotation);
        prefabCount++;
        }
        else
        {
            Debug.Log("프리팹의 최대 생성 개수에 도달했습니다.");
        }
    }
}
