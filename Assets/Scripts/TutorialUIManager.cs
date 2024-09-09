using System.Collections;
using UnityEngine;

public class TutorialUIManager : MonoBehaviour
{
    [SerializeField] public GameObject welcomeMenu;
    [SerializeField] public GameObject tutorialStep1Menu;
    [SerializeField] public GameObject tutorialStep2Menu;
    [SerializeField] public GameObject switchObject;
    [SerializeField] public GameObject nextObject;
    [SerializeField] public Camera camerita;
    //[SerializeField] public Transform user;

    public GameObject parentContainer;
    private int currentMenuIndex = 0;
    private GameObject[] menus;
    private Material outlineSwitch;
    private Material outlineNext;
    void Start()
    {
        Renderer renderer = switchObject.GetComponent<Renderer>();
        Renderer rendererNext = nextObject.GetComponent<Renderer>();

        if (renderer != null && rendererNext != null)
        {
            outlineSwitch = renderer.material;
            outlineSwitch.SetFloat("_Outline", 0.0f);
            outlineNext = rendererNext.material;
            outlineNext.SetFloat("_Outline", 0.0f);
        }
      
        menus = new GameObject[] { welcomeMenu, tutorialStep1Menu, tutorialStep2Menu};

        HideAllMenus();
        ShowMenu(currentMenuIndex);
    }

    private void HideAllMenus()
    {
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
    }

    private void ShowMenu(int index)
    {
        if (index >= 0 && index < menus.Length)
        {
            menus[index].SetActive(true);
            LeanTween.scale(parentContainer, Vector3.one, 0.5f).setEase(LeanTweenType.easeOutExpo);
        }
    }

    private void HideMenu(int index, System.Action onComplete = null)
    {
        if (index >= 0 && index < menus.Length)
        {
            LeanTween.scale(parentContainer, Vector3.zero, 0.5f).setEase(LeanTweenType.easeInExpo).setOnComplete(() =>
            {
                menus[index].SetActive(false);
                onComplete?.Invoke();
            });
        }
    }

    public void OnNextButtonPressed()
    {
        if (currentMenuIndex < menus.Length - 1)
        {
            HideMenu(currentMenuIndex, () => {
                currentMenuIndex++;
                if(currentMenuIndex == 2)
                {
                    outlineSwitch.SetFloat("_Outline", 0.03f);
                    StartCoroutine(DeactivateLastMenu());
                }
                ShowMenu(currentMenuIndex);
            });
        }
    }
    IEnumerator DeactivateLastMenu()
    {
        yield return new WaitForSeconds(5f);

        HideMenu(2);
    }
    public void CloseMenu(int index)
    {
        if (index < menus.Length - 1)
        {
            // Hide the current menu and show the next one using the callback
            HideMenu(index, () => {
                ShowMenu(currentMenuIndex+1);
            });
        }
    }
} 