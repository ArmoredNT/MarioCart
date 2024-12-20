using System;
using UnityEngine;
using System.Collections;
 
//[ExecuteInEditMode]
[AddComponentMenu("Image Effects/PixelBoy")]
public class PixelBoy : MonoBehaviour
{
    public int w = 720;
    int h;

    private Camera _camera;
    protected void Start()
    {
        _camera = GetComponent<Camera>();
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        float ratio = ((float)_camera.pixelHeight / (float)_camera.pixelWidth);
        h = Mathf.RoundToInt(w * ratio);
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        source.filterMode = FilterMode.Point;
        RenderTexture buffer = RenderTexture.GetTemporary(w, h, -1);
        buffer.filterMode = FilterMode.Point;
        Graphics.Blit(source, buffer);
        Graphics.Blit(buffer, destination);
        RenderTexture.ReleaseTemporary(buffer);
    }
}