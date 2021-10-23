using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShaderController : MonoBehaviour
{
    private List<Material> trippyMaterials;
    
    [SerializeField] private List<Texture> trippyTextures;
    [SerializeField] private int textureIndex = 0;
    [SerializeField] public float shaderSpeed = 0.1f;
    [SerializeField] public int textureChangeTicks = 50;
    
    private static readonly int TrippySpeed = Shader.PropertyToID("_trippySpeed");
    private static readonly int TrippyTexture = Shader.PropertyToID("_trippyTexture");
    private static readonly int TrippyOpacity = Shader.PropertyToID("_trippyOpacity");

    private int currentIndex;
    private float currentSpeed;
    public int currentOpacity;

    void Start()
    {
        var allRenderers = GetComponentsInChildren<Renderer>().ToList();
        trippyMaterials = allRenderers.Select(t => t.sharedMaterial).ToList();
        
        SetSpeed(shaderSpeed);
        ChangeTexture(textureIndex);

        StartCoroutine(ShowcaseTextures());
    }

    private void Update()
    {
        if (currentIndex != textureIndex)
            ChangeTexture(textureIndex);

        if (Math.Abs(currentSpeed - shaderSpeed) > 0.001)
            SetSpeed(shaderSpeed);
    }

    IEnumerator ShowcaseTextures()
    {
        int tick = 0;
        bool increase = true;
        while (true)
        {
            currentOpacity = (100 / textureChangeTicks) * tick;
            
            foreach (var trippyMaterial in trippyMaterials)
                trippyMaterial.SetFloat(TrippyOpacity, currentOpacity / 100f);

            if (tick >= textureChangeTicks)
                increase = false;
            else if (tick <= 0)
            {
                increase = true;
                textureIndex += 1;
                ChangeTexture(textureIndex);
            }

            if (increase)
                tick += 1;
            else
                tick -= 1;
            
            yield return new WaitForFixedUpdate();
        }
    }
    

    public void ChangeTexture(int index)
    {
        var tempIndex = index;
        if (index >= trippyTextures.Count)
            tempIndex = 0;
        
        if (index < 0)
            tempIndex = 0;
        
        foreach (var trippyMaterial in trippyMaterials)
            trippyMaterial.SetTexture(TrippyTexture, trippyTextures[tempIndex]);
        
        currentIndex = tempIndex;
        textureIndex = currentIndex;
    }

    public void SetSpeed(float speed)
    {
        foreach (var trippyMaterial in trippyMaterials)
            trippyMaterial.SetFloat(TrippySpeed, speed);
        
        currentSpeed = speed;
    }
}
