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
            ran[0] = Random.Range(0, items.Length-1);
            ran[1] = Random.Range(0, items.Length-1);
            ran[2] = items.Length-2;

            if (ran[0] != ran[1] && ran[1] != ran[2] && ran[0] != ran[2])
            {
                break;
            }
        }

        for (int i = 0 ; i < ran.Length ; i++)
        {
            Item ranItem = items[ran[i]];

            // Verificar si TODOS los items están al máximo nivel
            bool allItemsMaxed = true;
            for (int j = 0; j < items.Length - 2; j++) // -1 para excluir el item[5]
            {
                if (items[j].level < items[j].data.damages.Length)
                {
                    allItemsMaxed = false;
                    break;
                }
            }

            if (allItemsMaxed)
            {
                // Si todos están al máximo, mostrar solo el item especial
                items[5].gameObject.SetActive(true);
            }
            else
            {
                // Si no todos están al máximo, mostrar el item normal
                if (ranItem.level == ranItem.data.damages.Length)
                {
                    // Este item está al máximo, buscar otro
                    for (int k = 0; k < items.Length - 1; k++)
                    {
                        if (items[k].level < items[k].data.damages.Length)
                        {
                            items[k].gameObject.SetActive(true);
                            break;
                        }
                    }
                }
                else
                {
                    ranItem.gameObject.SetActive(true);
                }
            }
        }
    }
}
