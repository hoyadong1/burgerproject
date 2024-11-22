using UnityEngine;
using UnityEngine.UI;

public class ButtonTransparencyController : MonoBehaviour
{
    public float defaultTransparency = 180f / 255f;  // 기본 투명도 (0~1 사이로 설정)
    public float selectedTransparency = 250f / 255f; // 선택된 버튼의 투명도

    private Button lastSelectedButton; // 마지막으로 선택된 버튼을 추적

    // 모든 버튼의 초기 투명도를 설정
    void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            SetButtonTransparency(button, defaultTransparency);
            button.onClick.AddListener(() => OnButtonClicked(button));
        }
    }

    // 버튼 클릭 시 호출되는 함수
    void OnButtonClicked(Button clickedButton)
    {
        // 마지막으로 선택된 버튼이 있고 그것이 현재 클릭된 버튼과 다르면 기본 투명도로 변경
        if (lastSelectedButton != null && lastSelectedButton != clickedButton)
        {
            SetButtonTransparency(lastSelectedButton, defaultTransparency);
        }

        // 클릭된 버튼의 투명도를 선택된 투명도로 변경
        SetButtonTransparency(clickedButton, selectedTransparency);

        // 현재 클릭된 버튼을 마지막으로 선택된 버튼으로 설정
        lastSelectedButton = clickedButton;
    }

    // 버튼의 투명도를 설정하는 함수
    void SetButtonTransparency(Button button, float alpha)
    {
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
        {
            Color color = buttonImage.color;
            color.a = alpha;
            buttonImage.color = color;
        }
    }
}
