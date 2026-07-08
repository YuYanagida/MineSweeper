using R3;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustamMode : MonoBehaviour
{
    [SerializeField] private TMP_InputField _heightField;
    [SerializeField] private TMP_InputField _widthField;
    [SerializeField] private TMP_InputField _bomCountField;
    [SerializeField] private Button _custamButton;
    [SerializeField] private GameObject _fieldParent;

    private int _height;
    private int _width;
    private int _bomCount;

    public (int, int) Field => (_width, _height);
    public int BomCount => _bomCount;

    private void Awake()
    {
        _heightField.onValidateInput += OnValidateInput;
        _widthField.onValidateInput += OnValidateInput;
        _bomCountField.onValidateInput += OnValidateInput;

        _fieldParent.SetActive(false);

        _heightField.OnEndEditAsObservable().Subscribe(value =>
        {
            _height = int.Parse(value);
        }).AddTo(this);

        _widthField.OnEndEditAsObservable().Subscribe(value =>
        {
            _width = int.Parse(value);
        }).AddTo(this);

        _bomCountField.OnEndEditAsObservable().Subscribe(value =>
        {
            _bomCount = int.Parse(value);

        }).AddTo(this);

        _custamButton.OnClickAsObservable().Subscribe(_ =>
        {
            _fieldParent.SetActive(!_fieldParent.activeSelf);
        }).AddTo(this);
    }

    public bool IsInput()
    {
        return 
            !string.IsNullOrEmpty(_heightField.text) && 
            !string.IsNullOrEmpty(_widthField.text) && 
            !string.IsNullOrEmpty(_bomCountField.text) &&
            _bomCount < _height * _width;
    }

    private char OnValidateInput(string text, int index, char addedChar)
    {
        if (!char.IsDigit(addedChar) && addedChar > 0)
            return '\0';

        return addedChar;
    }
}
