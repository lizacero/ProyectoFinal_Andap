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
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[Mathf.Min(GameManager.instance.level, GameManager.instance.nextExp.Length - 1)];
                MySlider.value = curExp/maxExp;
                break;
            case InfoType.Level:
                break;

            case InfoType.Kill:
                 break;

            case InfoType.Time:
                break;

            case InfoType.Health:
                float curHealth = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                MySlider.value = curHealth/maxHealth;
                break;
        }
    }

}
