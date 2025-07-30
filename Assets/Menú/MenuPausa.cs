using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;

    private bool JuegoPausado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (JuegoPausado)
            {
                Reanudar();
            }
            else 
            { 
                Pausa();
            }
        }
    }

    public void Pausa() 
    {
        JuegoPausado = true;
        Time.timeScale = 0f;
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);

    }

    public void Reanudar() 
    {
        JuegoPausado = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void Reiniciar()
    {
        JuegoPausado = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Cerrar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
