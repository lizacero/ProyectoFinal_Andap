using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject botonPausa;
    [SerializeField] private GameObject menuPausa;
    [SerializeField] private AudioSource musicSource;
    private bool isSilenced = false;
    private float originalVolume;

    private bool JuegoPausado = false;

    private void Start()
    {
        originalVolume = musicSource.volume;
    }

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
        SceneManager.LoadScene(0);
    }

    public void ToggleMusic()
    {
        if (musicSource == null) return;
        
        if (isSilenced)
        {
            // Restaurar música
            musicSource.volume = originalVolume;
            isSilenced = false;
            Debug.Log("Música activada");
        }
        else
        {
            // Silenciar música
            musicSource.volume = 0f;
            isSilenced = true;
            Debug.Log("Música silenciada");
        }
    }

}
