using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaterialManager : MonoBehaviour
{
    private const byte k_MaxByteForOverexposedColor = 191; //internal Unity const
    [SerializeField] private Toggle _modulo;
    [SerializeField] private Slider _contrastSlider;
    [SerializeField] private Slider _metallicSlider;
    [SerializeField] private Slider _smothnessSlider;
    [SerializeField] private Toggle _gradientNoise;
    [SerializeField] private TMP_InputField _waveScale;
    [SerializeField] private TMP_InputField _waveSpeed;
    [SerializeField] private Toggle _emission;
    [SerializeField] private FlexibleColorPicker _emissionColor;
    [SerializeField] private Slider _emissionIntensitySlider;
    private Color emissionColorScriptValue;
    [SerializeField] private TMP_InputField _emissionAmount;


    [SerializeField] private Toggle _foam;
    [SerializeField] private FlexibleColorPicker _foamColor;
    [SerializeField] private Slider _foamIntensitySlider;
    private Color foamColorScriptValue;
    [SerializeField] private TMP_InputField _foamCutoff;
    [SerializeField] private TMP_InputField _foamAmount;
    [SerializeField] private TMP_InputField _foamSpeed;
    [SerializeField] private TMP_InputField _foamScale;

    [SerializeField] private Toggle _normalMap;
    [SerializeField] private Slider _normalMapSlider;


    [SerializeField] private Toggle _details;
    [SerializeField] private TMP_InputField _detailsOffsetX;
    [SerializeField] private TMP_InputField _detailsOffsetY;
    private float detailsXscript;
    private float detailsYscript;
    [SerializeField] private TMP_InputField _detailsStrengthX;
    [SerializeField] private TMP_InputField _detailsStrengthY;
    private float detailsStrengthXscript;
    private float detailsStrengthYscript;


    [SerializeField] private Toggle _radial;
    [SerializeField] private TMP_InputField _timeMultiplier;
    
    [SerializeField] private TMP_InputField _voronoiNoise;
    [SerializeField] private TMP_InputField _voronoiScale;


    [SerializeField] private Material mat;
    private ComboCounter _comboCounter;

    private void Start()
    {
        _comboCounter = GetComponent<ComboCounter>();
        SetStartValues();
    }

    public void Moodulo()
    {
        if (_modulo.isOn)
            mat.SetFloat("_Modulo", 1f);
        else
            mat.SetFloat("_Modulo", 0f);
    }

    public void SliderContrast()
    {
        mat.SetFloat("_Contrast", _contrastSlider.value);
    }

    public void SliderMetallic()
    {
        mat.SetFloat("_Metallic", _metallicSlider.value);
    }

    public void SliderSmothness()
    {
        mat.SetFloat("_Smothness", _smothnessSlider.value);
    }


    public void GradientNoise()
    {
        if (_gradientNoise.isOn)
            mat.SetFloat("_GraientNoise", 1f);
        else
            mat.SetFloat("_GraientNoise", 0f);
    }

    public void WaveScale()
    {
        mat.SetFloat("_WaveScale2", ConvertStringToFloat(_waveScale.text));
    }

    public void WaveSpeed()
    {
        mat.SetFloat("_WaveSpeed", ConvertStringToFloat(_waveSpeed.text));
    }

    public void Emission()
    {
        if (_emission.isOn)
            mat.SetFloat("_Emission", 1f);
        else
            mat.SetFloat("_Emission", 0f);
        
        _comboCounter.IncreaseCombo();
    }

    public void EmissionColor()
    {
        var col = ChangeHDRColorIntensity(_emissionColor.color, _emissionIntensitySlider.value);
        mat.SetColor("_EmissionColor", col);
        emissionColorScriptValue = mat.GetColor("_EmissionColor");
        
        
    }

    public void SliderEmissionIntensity()
    {
        var col = ChangeHDRColorIntensity(emissionColorScriptValue, _emissionIntensitySlider.value);
        mat.SetColor("_EmissionColor", col);
    }

    public void EmissionAmount()
    {
        mat.SetFloat("_EmissionAmount", ConvertStringToFloat(_emissionAmount.text));
    }

    public void Foam()
    {
        if (_foam.isOn)
            mat.SetFloat("_Foam", 1f);
        else
            mat.SetFloat("_Foam", 0f);
    }

    public void FoamColor()
    {
        var col = ChangeHDRColorIntensity(_foamColor.color, _foamIntensitySlider.value);
        mat.SetColor("_FoamColor", col);
        foamColorScriptValue = mat.GetColor("_FoamColor");
    }

    public void SliderFoamIntensity()
    {
        var col = ChangeHDRColorIntensity(foamColorScriptValue, _foamIntensitySlider.value);
        mat.SetColor("_FoamColor", col);
    }

    public void FoamCutoff()
    {
        mat.SetFloat("_FoamCutoff", ConvertStringToFloat(_foamCutoff.text));
    }

    public void FoamAmount()
    {
        mat.SetFloat("_FoamAmount", ConvertStringToFloat(_foamAmount.text));
    }

    public void FoamSpeed()
    {
        mat.SetFloat("_FoamSpeed", ConvertStringToFloat(_foamSpeed.text));
    }

    public void FoamScale()
    {
        mat.SetFloat("_FoamScale", ConvertStringToFloat(_foamScale.text));
    }

    public void NormalMap()
    {
        if (_normalMap.isOn)
            mat.SetFloat("_Normal_Map", 1f);
        else
            mat.SetFloat("_Normal_Map", 0f);
    }
    public void SliderNormalMapHeight()
    {
        mat.SetFloat("_NormalMapHeight", _normalMapSlider.value);
    }

    public void Details()
    {
        if (_details.isOn)
            mat.SetFloat("_Details", 1f);
        else
            mat.SetFloat("_Details", 0f);
    }
    public void DetailsOffsetX()
    {
        detailsXscript = ConvertStringToFloat(_detailsOffsetX.text);
        Vector4 offset = new Vector4(detailsXscript, detailsYscript, 0f, 0f);
        mat.SetVector("_DetailsOffset",offset );
    }
    public void DetailsOffsetY()
    {
        detailsYscript = ConvertStringToFloat(_detailsOffsetY.text);
        Vector4 offset = new Vector4(detailsXscript, detailsYscript, 0f, 0f);
        mat.SetVector("_DetailsOffset",offset );
    }
    public void DetailsStrengthX()
    {
        detailsStrengthXscript = ConvertStringToFloat(_detailsStrengthX.text);
        Vector4 strength = new Vector4(detailsStrengthXscript, detailsStrengthYscript, 0f, 0f);
        mat.SetVector("_DetailsStrength", strength );
    }
    public void DetailsStrengthY()
    {
        detailsStrengthYscript = ConvertStringToFloat(_detailsStrengthY.text);
        Vector4 strength = new Vector4(detailsStrengthXscript, detailsStrengthYscript, 0f, 0f);
        mat.SetVector("_DetailsStrength", strength );
    }
    
    public void Radial()
    {
        if (_radial.isOn)
            mat.SetFloat("_Raidal", 1f);
        else
            mat.SetFloat("_Raidal", 0f);
    }
    public void TimeMultiplier()
    {
        mat.SetFloat("_TimeMultiplier", ConvertStringToFloat(_timeMultiplier.text));
    }

    public void VoronoiNoise()
    {
        mat.SetFloat("_VoronoiNoiseMultiplier", ConvertStringToFloat(_voronoiNoise.text));
    }
    public void VoronoiScale()
    {
        mat.SetFloat("_VoronoiWaveScale", ConvertStringToFloat(_voronoiScale.text));
    }

    private void SetStartValues()
    {
        _modulo.isOn = Convert.ToBoolean(mat.GetFloat("_Modulo"));
        _contrastSlider.value = mat.GetFloat("_Contrast");
        _metallicSlider.value = mat.GetFloat("_Metallic");
        _smothnessSlider.value = mat.GetFloat("_Smothness");
        _gradientNoise.isOn = Convert.ToBoolean(mat.GetFloat("_GraientNoise"));
        _waveScale.text = mat.GetFloat("_WaveScale2").ToString();

        //emission
        _emission.isOn = Convert.ToBoolean(mat.GetFloat("_Emission"));
        var emissionCol = mat.GetColor("_EmissionColor");
        emissionColorScriptValue = emissionCol;
        _emissionColor.SetColor(emissionCol);
        _emissionIntensitySlider.value = (emissionCol.r + emissionCol.g + emissionCol.b) / 3f;
        _emissionAmount.text = mat.GetFloat("_EmissionAmount").ToString();

        //foam
        _foam.isOn = Convert.ToBoolean(mat.GetFloat("_Foam"));
        _foamCutoff.text = mat.GetFloat("_FoamCutoff").ToString();
        _foamAmount.text = mat.GetFloat("_FoamAmount").ToString();
        _foamSpeed.text = mat.GetFloat("_FoamSpeed").ToString();
        _foamScale.text = mat.GetFloat("_FoamScale").ToString();
        
        //normal map
        _normalMap.isOn = Convert.ToBoolean(mat.GetFloat("_Normal_Map"));
        _normalMapSlider.value = mat.GetFloat("_NormalMapHeight");
        
        //detail
        _details.isOn = Convert.ToBoolean(mat.GetFloat("_Details"));
        Vector4 dOffset = mat.GetVector("_DetailsOffset");
        _detailsOffsetX.text = dOffset.x.ToString();
        _detailsOffsetY.text = dOffset.y.ToString();
        detailsXscript = dOffset.x;
        detailsYscript = dOffset.y;
        Vector4 sOffset = mat.GetVector("_DetailsStrength");
        _detailsStrengthX.text = sOffset.x.ToString();
        _detailsStrengthY.text = sOffset.y.ToString();
        detailsStrengthXscript = sOffset.x;
        detailsStrengthYscript = sOffset.y;
        
        //radial
        _radial.isOn = Convert.ToBoolean(mat.GetFloat("_Raidal"));
        _timeMultiplier.text = mat.GetFloat("_TimeMultiplier").ToString();
        
        //voronoi
        _voronoiNoise.text = mat.GetFloat("_VoronoiNoiseMultiplier").ToString();
        _voronoiScale.text = mat.GetFloat("_VoronoiWaveScale").ToString();
    }

    private float ConvertStringToFloat(string str)
    {
        float num;
        if (str == "")
        {
            num = 0;
        }
        else
        {
            num = float.Parse(str);
        }

        return num;
    }
    

    private Color ChangeHDRColorIntensity(Color subjectColor, float intensityChange)
    {
        // Get color intensity
        float maxColorComponent = subjectColor.maxColorComponent;
        float scaleFactorToGetIntensity = k_MaxByteForOverexposedColor / maxColorComponent;
        float currentIntensity = Mathf.Log(255f / scaleFactorToGetIntensity) / Mathf.Log(2f);

        // Get original color with ZERO intensity
        float currentScaleFactor = Mathf.Pow(2, currentIntensity);
        Color originalColorWithoutIntensity = subjectColor / currentScaleFactor;

        // Add color intensity
        float modifiedIntensity = currentIntensity + intensityChange;

        // Set color intensity
        float newScaleFactor = Mathf.Pow(2, modifiedIntensity);
        Color colorToRetun = originalColorWithoutIntensity * newScaleFactor;

        // Return color
        return colorToRetun;
    }
}