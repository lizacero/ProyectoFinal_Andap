using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadScene : MonoBehaviour
{
    public GameObject PantallaNivel;
    public GameObject PantallaVictoria;
    public GameObject PantallaDerrota;

    public void Update()
    {

    }


    public void Victoria()
    {
            PantallaVictoria.SetActive(true);
            Time.timeScale = 0;
    }

    public void Derrota()
    {
        if (GameManager.instance.health <=0)
        {
            StartCoroutine(DelayDerrota());
        }
    }

    public IEnumerator DelayDerrota()
    {
        yield return new WaitForSeconds(0.5f);
        PantallaDerrota.SetActive(true);
        Time.timeScale = 0;
    }

}
