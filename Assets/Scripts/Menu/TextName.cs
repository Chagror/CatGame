using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextName : MonoBehaviour
{
    private Camera _camera;
    private TextMeshProUGUI _textMeshPro;
    private Player _player;
    void Start()
    {
        _textMeshPro = GetComponentInParent<TextMeshProUGUI>();
        _player = GetComponentInParent<Player>();
        _camera = Camera.main;
        
        Color playerColor;
        ColorUtility.TryParseHtmlString(_player.GetColor(), out playerColor);

        _textMeshPro.text = _player.GetName();
        _textMeshPro.color = playerColor;
    }

    void LateUpdate()
    {
        transform.LookAt(_camera.transform);
        transform.rotation = Quaternion.LookRotation(_camera.transform.forward);
    }
}
