using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class TextureController : Singleton<TextureController>
{
    public List<Button> buttons;
    public TextMeshProUGUI debugger;
    public UnityEngine.XR.ARFoundation.Samples.PrefabImagePairManager manager;

    void Start()
    {
        buttons.ForEach((b)=> {
            b.onClick.AddListener(()=> {
                manager.GetComponent<ARTrackedImageManager>().
                GetComponentInChildren<ARObject>().SetTexture(b.transform.GetSiblingIndex());
                debugger.SetText("click"+ b.transform.GetSiblingIndex());
            });
        });
    }

    public void SetDebuggingText(string text)
    {
        debugger.SetText(text);
    }
}
