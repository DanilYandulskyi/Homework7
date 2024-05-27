using UnityEngine;
using System.Collections.Generic;

public class ColorSeter : MonoBehaviour
{
    [SerializeField] private List<Material> _colors;
    
    public void SetColor(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Renderer renderer))
        {
            Material material = _colors[NumberGenerator.GenerateNumber(0, _colors.Count)];

            renderer.material = material;
        }
    }
}
