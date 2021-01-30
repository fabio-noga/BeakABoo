using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TransparentObject : MonoBehaviour
{
    public Material tree;
    public Camera main;
    private MeshRenderer meshRenderer;
    private Color matcolor;

    public enum RenderingMode
    {
        Opaque,
        Transparent
    }

    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        tree = meshRenderer.material;
        main = Camera.main;
        matcolor = tree.color;
    }
    
    void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetMaterialRenderingModeToTransparent();
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            SetMaterialRenderingModeToOpaque();
        }
    }
    
    public void SetMaterialRenderingModeToTransparent()
    {
        MaterialExtensions.ToFadeMode(tree);
        matcolor.a = 0.25f;
        tree.color = matcolor;
    }
    
    public void SetMaterialRenderingModeToOpaque()
    {
        MaterialExtensions.ToOpaqueMode(tree);
        matcolor.a = 1f;
        tree.color = matcolor;
    }
}
