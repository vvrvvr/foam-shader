using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Linq;

public class TextureDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TextMeshProUGUI previewImage;
    public Material _mat;
    public Material _handMat;
    private List<Texture2D> textures = new List<Texture2D>();
    private List<string> textureNames = new List<string>();
    [SerializeField] private Image _img;

    string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
    string foamSavedMaterialPath;
    private int savedTextureNumber = 1;

    private SaveAndLoadMatSettings _saveAndLoadMat;


    void Start()
    {
        LoadTextures();
        PopulateDropdown();
        OnDropdownValueChanged();
        foamSavedMaterialPath = Path.Combine(desktopPath, "FoamSavedMaterial");
        _saveAndLoadMat = GetComponent<SaveAndLoadMatSettings>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if(savedTextureNumber >1)
                _saveAndLoadMat.LoadMaterialSettingsFromJson(_mat, savedTextureNumber);
        }
    }

    void LoadTextures()
    {
        string desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop);
        string[] imageFiles = Directory.GetFiles(desktopPath, "*.png");
        imageFiles = imageFiles.Concat(Directory.GetFiles(desktopPath, "*.jpg")).ToArray();

        foreach (string filePath in imageFiles)
        {
            byte[] fileData = File.ReadAllBytes(filePath);
            Texture2D tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
            textures.Add(tex);
            textureNames.Add(Path.GetFileNameWithoutExtension(filePath));
        }
    }

    void PopulateDropdown()
    {
        dropdown.ClearOptions();

        dropdown.AddOptions(textureNames);
        dropdown.onValueChanged.AddListener(delegate { OnDropdownValueChanged(); });
    }

    void OnDropdownValueChanged()
    {
        int index = dropdown.value;
        // label.text = dropdown.options[index].text;
        _mat.mainTexture = textures[index];
        _handMat.mainTexture = textures[index];
        Sprite sprite = Sprite.Create(textures[index], new Rect(0, 0, textures[index].width, textures[index].height), Vector2.zero);
        _img.sprite = sprite;
    }

    public void SaveMaterialAndTexture()
    {
        if(!Directory.Exists(foamSavedMaterialPath))
            Directory.CreateDirectory(foamSavedMaterialPath);
        
        _saveAndLoadMat.SaveMaterialSettingsToJson(_mat,savedTextureNumber );
        
        Texture2D texture = _mat.mainTexture as Texture2D;
        if (texture != null)
        {
            byte[] bytes = texture.EncodeToPNG();
            string texturename = "FoamTexture" +savedTextureNumber;
            savedTextureNumber++;
            File.WriteAllBytes(Path.Combine(foamSavedMaterialPath, $"{texturename}.png"), bytes);
        }
    }
}