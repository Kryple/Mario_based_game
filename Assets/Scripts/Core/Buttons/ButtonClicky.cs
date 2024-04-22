using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonClicky : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _default, _pressed;

    [SerializeField] private ButtonResourcesList _buttonResourcesList;
    [SerializeField] private int _defaultSpriteID = 0, _pressedSpriteID = 0;
    
    
    RectTransform _rectTransform;
    float _changeY = 5.6f;
    
    private Vector3 localScaleOld;

    [SerializeField] private float scaleRate = 0.9f;
    [SerializeField] private bool isFxz = true; //fxz

    private void Awake() 
    {
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
        
        
        _default = _buttonResourcesList._defaultButtonSprites[_defaultSpriteID];
        _pressed = _buttonResourcesList._pressedButtonSprites[_pressedSpriteID];
        _image.sprite = _default;
        
        localScaleOld = this.transform.localScale;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _default;
        AudioManager.Instance.Play(AudioEnum.UncompressedButton);
        

        Vector2 anchoredPosition = _rectTransform.anchoredPosition;

        // Modify the Y component to the new value
        anchoredPosition.y += _changeY;

        // Assign the modified anchored position back to the RectTransform
        _rectTransform.anchoredPosition = anchoredPosition;
        
        if (isFxz)
            transform.localScale = localScaleOld;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = _pressed;
        
        AudioManager.Instance.Play(AudioEnum.CompressedButton);
        
        Vector2 anchoredPosition = _rectTransform.anchoredPosition;

        // Modify the Y component to the new value
        anchoredPosition.y -= _changeY;

        // Assign the modified anchored position back to the RectTransform
        _rectTransform.anchoredPosition = anchoredPosition;
        
        if (isFxz)
            transform.localScale = localScaleOld * scaleRate;
        
        Debug.Log("Check");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Module.MediumVibrate();
    }
}

