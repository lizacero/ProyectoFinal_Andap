using UnityEngine;

public class LevelUp : MonoBehaviour
{
    RectTransform rect;
    Item[] items;
    public AudioSource audioSource;
    public AudioClip LevelUpClip;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
        items = GetComponentsInChildren<Item>(true);
    }

    public void Show()
    {
        Next();
        rect.localScale = Vector3.one;
        GameManager.instance.Stop();
    }

    public void Hide()
    {
        rect.localScale = Vector3.zero;
        GameManager.instance.Resume();
    }

    public void Select(int index)
    {
        if (index < 0 || index >= items.Length)
        {
            Debug.LogError($"Índice {index} fuera de rango en LevelUp.Select()");
            return;
        }

        if (items[index] == null)
        {
            Debug.LogError($"Item en índice {index} es null");
            return;
        }
        items[index].OnClick();
    }

    void Next()
    {
        if (audioSource != null && LevelUpClip != null)
        {
            audioSource.PlayOneShot(LevelUpClip);
        }

            foreach (Item item in items)
            {
                item.gameObject.SetActive(false);
            }

        int[] ran = new int[3];
        while (true)
        {
            ran[0] = Random.Range(0, items.Length);
            ran[1] = Random.Range(0, items.Length);
            ran[2] = Random.Range(0, items.Length);

            if (ran[0] != ran[1] && ran[1] != ran[2] && ran[0] != ran[2])
            {
                break;
            }
        }
        for (int i = 0 ; i < ran.Length ; i++)
            {
                Item ranItem = items[ran[i]];

                if (ranItem.level == ranItem.data.damages.Length)
                {
                    items[4].gameObject.SetActive(true);
                }
                else
                {
                    ranItem.gameObject.SetActive(true);
                }
            }
    }
}
