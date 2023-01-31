using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MainController : Singleton<MainController>
{
    public Transform buttonParent;
    public GameObject buttonPrefab;
    public TextMeshProUGUI debugger;

    [HideInInspector]
    public GameObject currentObject;

    public void SetDebuggingText(string text)
    {
        debugger.SetText(text);
    }

    public void OnSpawn(AR_Object ar_object)
    {
        currentObject = ar_object.gameObject;

        for (int i = 0; i < ar_object.textures.Count; i++)
        {
            GameObject cloneButton = Instantiate(buttonPrefab, buttonParent);
            cloneButton.GetComponentInChildren<TextMeshProUGUI>().SetText(ar_object.textures[i].name);
            cloneButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                ar_object.SetTexture(cloneButton.transform.GetSiblingIndex());
            });
        }
    }
}
