using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public PlayerHealth _health;

    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _text.text = $"Health: {_health._health}";
    }
}
