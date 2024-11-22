using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public int bulgogiBurger;
    public int shrimpBurger;
    public int cheeseBurger;

    public int frenchFries;
    public int cheeseStick;
    public int chickenNuggets;

    public int coke;
    public int cider;
    public int zeroCoke;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시 파괴되지 않도록 설정
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 있으면 새로 생성된 것은 파괴
        }
    }
}
