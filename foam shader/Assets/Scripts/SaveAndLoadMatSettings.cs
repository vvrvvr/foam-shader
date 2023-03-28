using System;
using UnityEngine;
using System.IO;

public class SaveAndLoadMatSettings : MonoBehaviour
{
    private CaptureScreenshot _captureScreenshot;
    private string filePath;
    [SerializeField]

    private void Start()
    {
        _captureScreenshot = GetComponent<CaptureScreenshot>();
        // Указываем путь для сохранения и загрузки файла
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        filePath = Path.Combine(desktopPath, "FoamSavedMaterial"); //, "materialSettings.json");
    }

    public void SaveMaterialSettingsToJson(Material _mat, int number)
    {
        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }
        // Создаем объект для хранения настроек материала
        MaterialSettings matSettings = new MaterialSettings(_mat);

        // Преобразуем настройки материала в JSON
        string jsonData = JsonUtility.ToJson(matSettings);

        // Записываем JSON в файл
        string matName = "materialSettings" + number;
        File.WriteAllText(Path.Combine(filePath, $"{matName}.json"), jsonData);
        _captureScreenshot.MakeScreenshot();
        Debug.Log("texture and material saved");
    }

    public void LoadMaterialSettingsFromJson(Material _mat , int number)
    {
        // Читаем JSON из файла
        string matName = "materialSettings" + --number;
        string jsonData = File.ReadAllText(Path.Combine(filePath, $"{matName}.json"));

        // Преобразуем JSON в объект настроек материала
        MaterialSettings matSettings = JsonUtility.FromJson<MaterialSettings>(jsonData);

        // Применяем настройки материала
        matSettings.ApplyToMaterial(_mat);
    }
}

// Класс для хранения настроек материала
[System.Serializable]
public class MaterialSettings
{
    // Texture
    public Texture2D _MainTex;
    public float _Modulo;
    public float _Contrast;

    // Metallic and Smoothness
    public float _Metallic;
    public float _Smoothness;

    // Gradient Noise
    public float _GradientNoise;
    public float _WaveScale2;
    public float _WaveSpeed;

    // Emission
    public float _Emission;
    public Color _EmissionColor;
    public float _EmissionAmount;

    // Foam
    public float _Foam;
    public Color _FoamColor;
    public float _FoamCutoff;
    public float _FoamAmount;
    public float _FoamSpeed;
    public float _FoamScale;

    // Normal Map
    public float _Normal_Map;
    public float _NormalMapHeight;

    // Details
    public float _Details;
    public Vector4 _DetailsOffset;
    public Vector4 _DetailsStrength;

    // Radial
    public float _Raidal;
    public float _TimeMultiplier;
    public float _VoronoiNoiseMultiplier;
    public float _VoronoiWaveScale;

    public MaterialSettings(Material mat)
    {
        // Texture
        _MainTex = (Texture2D)mat.GetTexture("_MainTex");
        _Modulo = mat.GetFloat("_Modulo");
        _Contrast = mat.GetFloat("_Contrast");

        // Metallic and Smoothness
        _Metallic = mat.GetFloat("_Metallic");
        _Smoothness = mat.GetFloat("_Smothness");

        // Gradient Noise
        _GradientNoise = mat.GetFloat("_GraientNoise");
        _WaveScale2 = mat.GetFloat("_WaveScale2");
        _WaveSpeed = mat.GetFloat("_WaveSpeed");

        // Emission
        _Emission = mat.GetFloat("_Emission");
        _EmissionColor = mat.GetColor("_EmissionColor");
        _EmissionAmount = mat.GetFloat("_EmissionAmount");

        // Foam
        _Foam = mat.GetFloat("_Foam");
        _FoamColor = mat.GetColor("_FoamColor");
        _FoamCutoff = mat.GetFloat("_FoamCutoff");
        _FoamAmount = mat.GetFloat("_FoamAmount");
        _FoamSpeed = mat.GetFloat("_FoamSpeed");
        _FoamScale = mat.GetFloat("_FoamScale");

        // Normal Map
        _Normal_Map = mat.GetFloat("_Normal_Map");
        _NormalMapHeight = mat.GetFloat("_NormalMapHeight");

        // Details
        _Details = mat.GetFloat("_Details");
        _DetailsOffset = mat.GetVector("_DetailsOffset");
        _DetailsStrength = mat.GetVector("_DetailsStrength");

        // Radial
        _Raidal = mat.GetFloat("_Raidal");
        _TimeMultiplier = mat.GetFloat("_TimeMultiplier");
        _VoronoiNoiseMultiplier = mat.GetFloat("_VoronoiNoiseMultiplier");
        _VoronoiWaveScale = mat.GetFloat("_VoronoiWaveScale");
    }


    public void ApplyToMaterial(Material mat)
    {
        mat.SetTexture("_MainTex", _MainTex);
        mat.SetFloat("_Modulo", _Modulo);
        mat.SetFloat("_Contrast", _Contrast);
        mat.SetFloat("_Metallic", _Metallic);
        mat.SetFloat("_Smothness", _Smoothness);
        mat.SetFloat("_GraientNoise", _GradientNoise);
        mat.SetFloat("_WaveScale2", _WaveScale2);
        mat.SetFloat("_WaveSpeed", _WaveSpeed);
        mat.SetFloat("_Emission", _Emission);
        mat.SetColor("_EmissionColor", _EmissionColor);
        mat.SetFloat("_EmissionAmount", _EmissionAmount);
        mat.SetFloat("_Foam", _Foam);
        mat.SetColor("_FoamColor", _FoamColor);
        mat.SetFloat("_FoamCutoff", _FoamCutoff);
        mat.SetFloat("_FoamAmount", _FoamAmount);
        mat.SetFloat("_FoamSpeed", _FoamSpeed);
        mat.SetFloat("_FoamScale", _FoamScale);
        mat.SetFloat("_Normal_Map", _Normal_Map);
        mat.SetFloat("_NormalMapHeight", _NormalMapHeight);
        mat.SetFloat("_Details", _Details);
        mat.SetVector("_DetailsOffset", _DetailsOffset);
        mat.SetVector("_DetailsStrength", _DetailsStrength);

        mat.SetFloat("_Raidal", _Raidal);
        mat.SetFloat("_TimeMultiplier", _TimeMultiplier);
        mat.SetFloat("_VoronoiNoiseMultiplier", _VoronoiNoiseMultiplier);
        mat.SetFloat("_VoronoiWaveScale", _VoronoiWaveScale);
    }
}