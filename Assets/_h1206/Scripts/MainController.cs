using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainController : Singleton<MainController>
{
    public Transform buttonAnchors;
    public GameObject buttonParentPrefab;
    public GameObject buttonPrefab;
    public Button resetButton;
    public TextMeshProUGUI debugger;

    [HideInInspector]
    public List<InteractableObject> objects;

    [HideInInspector]
    public List<Transform> anchors;

    int currentIndex = -1;
    void Start()
    {
        resetButton.onClick.AddListener(()=> {
            objects[currentIndex].Reset();
        });
    }

    void Update()
    {
        
    }

    public void SetDebuggingText(string text)
    {
        debugger.SetText(text);
    }

    public void SetFocusedObject(InteractableObject target)
    {
        if (currentIndex == objects.IndexOf(target))
            return;

        currentIndex = objects.IndexOf(target);

        anchors.ForEach((a) => {
            a.gameObject.SetActive(false);
        });

        anchors[currentIndex].gameObject.SetActive(true);
    }
}
