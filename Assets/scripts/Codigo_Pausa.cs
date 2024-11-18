using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Codigo_Pausa : MonoBehaviour
{
    public GameObject ObjectoMenuPausa;
    public bool Pausa = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pausa == false)
            {
                ObjectoMenuPausa.gameObject.SetActive(true);
                Pausa = true;
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Pausa == true)
            {
                Resumir();
            }
        }
    }

    public void Resumir()
    {
        ObjectoMenuPausa.SetActive(false);
        Pausa = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void IrAlmenu(string NombreMenu)
    {
        SceneManager.LoadScene(NombreMenu);
    }

    public void SalirDelJuego()
    {
        Application.Quit();

        // Para el editor de Unity, puedes usar esto
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}
    