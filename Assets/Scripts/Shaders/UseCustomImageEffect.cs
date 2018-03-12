using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class UseCustomImageEffect : MonoBehaviour
{
    public Material EffectMaterial;
    [SerializeField] private float saturation = 1.0f;
    [SerializeField] private float doDisplace = 0.0f; // Booleans can't be passed to shaders.
    [SerializeField] private float displacement = 0.005f;
    [SerializeField] private float doHalo = 0.0f; // Booleans can't be passed to shaders.
    [SerializeField] private float haloAmount = 0.0f;

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (EffectMaterial != null)
        {
            EffectMaterial.SetFloat("_SatMagnitude", saturation);
            EffectMaterial.SetFloat("_Displace", doDisplace);
            EffectMaterial.SetFloat("_DisMagnitude", displacement);
            EffectMaterial.SetFloat("_Halo", doHalo);
            EffectMaterial.SetFloat("_HaloMagnitude", haloAmount);
            
            Graphics.Blit(src, dst, EffectMaterial);
        }  
    }

    public void lerpSaturationValue(float time, float newValue)
    {
        IEnumerator co = doLerpSat(time, newValue);
        StartCoroutine(co);
    }

    public void lerpHaloValue(float time, float newValue)
    {
        IEnumerator co = doLerpHalo(time, newValue);
        StartCoroutine(co);
    }

    public float getSaturationValue()
    {
        return saturation;
    }

    public void setSaturationValue(float sat)
    {
        saturation = sat;
    }

    public float getDisplacementAmount()
    {
        return displacement;
    }

    public void setDisplaceAmount(float amount)
    {
        displacement = amount;
    }


    public bool isDoingDisplacement()
    {
        return (doDisplace == 1.0f);
    }

    public void setDoDisplacement(bool dis)
    {
        if (dis)
        {
            doDisplace = 1.0f;
        }
        else
        {
            doDisplace = 0.0f;
        }
    }

    public float getHaloAmount()
    {
        return haloAmount;
    }

    public void setHaloAmount(float amount)
    {
        haloAmount = amount;
    }

    public bool isDoingHalo()
    {
        return (doHalo == 1.0f);
    }

    public void setDoHalo(bool halo)
    {
        if (halo)
        {
            doHalo = 1.0f;
        }
        else
        {
            doHalo = 0.0f;
        }
    }

    private IEnumerator doLerpSat(float time, float newValue)
    {
        IEnumerator co = lerpSat(time, newValue);
        StartCoroutine(co);
        yield return new WaitForSeconds(time);
        StopCoroutine(co);
    }

    private IEnumerator lerpSat(float time, float newSat)
    {
        float oldSat = saturation;
        float passedTime = 0.0f;

        while (true)
        {
            yield return null;
            passedTime += Time.deltaTime;

            float t = passedTime / time;
            saturation = Mathf.Lerp(oldSat, newSat, t);
        }
    }

    private IEnumerator doLerpHalo(float time, float newValue)
    {
        IEnumerator co = lerpHalo(time, newValue);
        StartCoroutine(co);
        yield return new WaitForSeconds(time);
        StopCoroutine(co);
    }

    private IEnumerator lerpHalo(float time, float newHalo)
    {
        float oldHalo = haloAmount;
        float passedTime = 0.0f;

        while (true)
        {
            yield return null;
            passedTime += Time.deltaTime;

            float t = passedTime / time;
            haloAmount = Mathf.Lerp(oldHalo, newHalo, t);
        }
    }
}