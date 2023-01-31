using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AR_Object : MonoBehaviour
{
    public List<Texture> textures;
    MainController mc;

    public void SetTexture(int index)
    {
        GetComponent<Renderer>().material.mainTexture = textures[index];
    }

    void Start()
    {
        mc = MainController.Instance;
        mc.OnSpawn(GetComponent<AR_Object>());
    }
}
