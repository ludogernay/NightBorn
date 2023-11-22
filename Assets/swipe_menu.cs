using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class swipe_menu : MonoBehaviour
{
    public GameObject scrollbar;
    float scroll_pos = 0;
    float[] pos;

    // Ajout d'une variable pour stocker la position du bouton actuel
    private int currentButtonIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Ajouter un écouteur d'événements pour le clic sur le bouton
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(() => OnButtonClick(button));
        }
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int a = 0; a < pos.Length; a++)
                {
                    if (a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }
    }

    // Méthode appelée lorsqu'un bouton est cliqué
    void OnButtonClick(Button button)
    {
        // Récupérer l'index du bouton cliqué
        int buttonIndex = System.Array.IndexOf(transform.GetComponentsInChildren<Button>(), button);

        // Passer au bouton suivant
        currentButtonIndex = (currentButtonIndex + 1) % pos.Length;

        // Reproduire l'effet de slide en ajustant la valeur de la scrollbar
        scrollbar.GetComponent<Scrollbar>().value = pos[currentButtonIndex];
    }
}

// targetButtonIndex = System.Array.IndexOf(transform.GetComponentsInChildren<Button>(), button);