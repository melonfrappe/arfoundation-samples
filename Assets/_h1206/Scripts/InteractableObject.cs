using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.UI;
using TMPro;

public class InteractableObject : MonoBehaviour
{
    public Renderer target;
    public List<Texture> textures;
    MainController mc;
    ARScaleInteractable a;

    public void SetTexture(int index)
    {
        if (textures.Count != 0)
            target.material.mainTexture = textures[index];
    }

    public void Reset()
    {
        a.enabled = false;
        transform.localEulerAngles = Vector3.zero;
        transform.localScale = Vector3.one;
        SetTexture(0);
        a.enabled = true;
    }

    void Start()
    {
        a = GetComponent<ARScaleInteractable>();
        mc = MainController.Instance;
        mc.objects.Add(this);

        GameObject cp = Instantiate(mc.buttonParentPrefab, mc.buttonAnchors);
        mc.anchors.Add(cp.transform);

        for (int i = 0; i < textures.Count; i++)
        {
            GameObject cb = Instantiate(mc.buttonPrefab, cp.transform);
            cb.GetComponentInChildren<TextMeshProUGUI>().SetText(textures[i].name);
            cb.GetComponent<Button>().onClick.AddListener(() =>
            {
                SetTexture(cb.transform.GetSiblingIndex());
            });
        }

        mc.SetFocusedObject(this);
    }

    public void OnSelectEntered()
    {
        mc.SetFocusedObject(this);
    }
    public void OnSelectExited()
    {

    }
}
