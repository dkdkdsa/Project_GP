using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSettingUI : MonoBehaviour
{
    public readonly string FromColorMatName = "_ColorReplaceToColor";
    
    [SerializeField] private List<Image> _colorImages = null;
    private List<Material> _mats = new();

    private void Awake()
    {
        foreach (var image in _colorImages)
        {
            image.material = Instantiate(image.material);
            _mats.Add(image.materialForRendering);
        }
    }

    public void OnColorChanged(int type)
    {
        DataManager.Instance.PlayerColorType = (PlayerColorType)type;

        foreach (var mat in _mats)
        {
            mat.SetColor("_ColorReplaceToColor", PlayerColor.GetColor((PlayerColorType)type));
        }
    }
}
