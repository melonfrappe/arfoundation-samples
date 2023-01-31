using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObject : MonoBehaviour
{
    public List<Texture> textures;
    TextureController tc;

    public void SetTexture(int index)
    {
        GetComponent<Renderer>().material.mainTexture = textures[index];
    }
}
