using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public enum InfoType { Exp,Level,Kill, Time,Health }
    public InfoType type;

    Text MyText;
    Slider MySlider;

    private void Awake()
    {
        MyText = GetComponent<Text>();
        MySlider = GetComponent<Slider>();
    }

    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Exp:
                break;
                float curExp; 
                float maxExp;
                MySlider.value = curExp/maxExp;
            case InfoType.Level:
                break;

            case InfoType.Kill:
                 break;

            case InfoType.Time:
                break;

            case InfoType.Health:
                break;
        }
    }

}
