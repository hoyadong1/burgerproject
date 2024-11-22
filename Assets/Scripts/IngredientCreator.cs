using UnityEngine;

public class IngredientCreator : MonoBehaviour
{
    // 생성할 프리팹
    public GameObject prefabToSpawn;
    
    // 프리팹의 생성 위치들
    public Vector3[] spawnLocations = { new Vector3(-4, 1, 0), new Vector3(-4, -1, 0), new Vector3(-4, -3, 0) };
    
    // 특정 태그를 가진 오브젝트가 있어야 생성되도록
    public string requiredTag = "Heel";
    
    // 현재 생성된 프리팹 수
    private int prefabCount = 0;

    void OnMouseDown()
    {
        // 프리팹의 최대 생성 수(3개)를 확인
        if (prefabCount < 3)
        {
            // 지정된 위치에 특정 태그를 가진 오브젝트가 있는지 확인
            Collider2D collider = Physics2D.OverlapCircle(spawnLocations[prefabCount], 0.5f);
            if (collider != null && collider.CompareTag(requiredTag))
            {
                // 특정 태그를 가진 오브젝트가 있을 때 해당 오브젝트를 부모로 하여 프리팹 생성
                GameObject spawnedObject = Instantiate(prefabToSpawn, spawnLocations[prefabCount], prefabToSpawn.transform.rotation, collider.transform);
                prefabCount++;
            }
            else
            {
                Debug.Log("지정된 위치에 " + requiredTag + " 태그가 있는 오브젝트가 없습니다.");
            }
        }
        else
        {
            Debug.Log("프리팹의 최대 생성 개수에 도달했습니다.");
        }
    }
}
