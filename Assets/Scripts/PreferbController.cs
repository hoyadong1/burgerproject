using UnityEngine;

public class PrefabController : MonoBehaviour
{
    private ServiceManager serviceManager;

    void Start()
    {
        // 같은 씬에 있는 ServiceManager를 찾음
        serviceManager = FindObjectOfType<ServiceManager>();
    }

    void OnMouseDown()
    {
        // 프리팹이 터치되면 ServiceManager에 알림
        if (serviceManager != null)
        {
            serviceManager.OnPrefabSelected(gameObject);
        }
        else
        {
            Debug.Log("no sevicemanager");
        }
    }
}
