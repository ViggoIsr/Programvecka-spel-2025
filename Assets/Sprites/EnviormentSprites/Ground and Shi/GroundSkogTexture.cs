using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScript : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.drawMode = SpriteDrawMode.Tiled;
        sr.size = new Vector2(10, 1); // Adjust width & height
    }
}
