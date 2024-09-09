using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [Header("Menus")]
    [SerializeField] private RectTransform rectComponent;
    [SerializeField] private GameObject mainMenu;
    private void Start()
    {    
        rectComponent.localScale = new Vector3(0, 0);
    }
    public void OnNewGame()
    {
        rectComponent.localScale = new Vector3(0.7f, 0.7f);
        mainMenu.SetActive(false);
        StartCoroutine(loadGameAsync());
    }
    IEnumerator loadGameAsync()
    {
        yield return new WaitForSeconds(1f);

        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        loadOperation.allowSceneActivation = false;

        while (!loadOperation.isDone)
        {
            rectComponent.Rotate(0f, 0f, 1200 * Time.deltaTime);
            if (loadOperation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(2f);
                loadOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

    public void OnQuitGame()
    {
        Application.Quit(); 
    }
}
