using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComboCounter : MonoBehaviour
{
    private int _comboCounter = 0;
    [SerializeField] private float _maxTimeBetweenCombos = 2.0f;
    private float _lastComboTime = 0.0f;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GameObject _textObject;

    public void IncreaseCombo()
    {
        if (Time.time - _lastComboTime <= _maxTimeBetweenCombos)
        {
            _comboCounter++;
        }
        else
        {
            _comboCounter = 1;
        }

        _lastComboTime = Time.time;

        if (_comboCounter > 1)
        {
            _textObject.SetActive(true);
            _text.text = "Combo x" + _comboCounter;
        }
    }

    private void Update()
    {
        if (Time.time - _lastComboTime > _maxTimeBetweenCombos)
        {
            _comboCounter = 0;
            _textObject.SetActive(false);
        }
    }
}

// using UnityEngine;
// using UnityEngine.UI;
// using DamageNumbersPro;
//
// public class ComboCounter : MonoBehaviour
// {
//     private int _comboCounter = 0;
//     [SerializeField] private float _maxTimeBetweenCombos = 2.0f;
//     private float _lastComboTime = 0.0f;
//     [SerializeField] private DamageNumbers _damageNumbers;
//
//     public void IncreaseCombo()
//     {
//         if (Time.time - _lastComboTime <= _maxTimeBetweenCombos)
//         {
//             _comboCounter++;
//         }
//         else
//         {
//             _comboCounter = 1;
//         }
//
//         _lastComboTime = Time.time;
//
//         if (_comboCounter > 1)
//         {
//             _damageNumbers.Display(_comboCounter.ToString(), transform.position);
//         }
//     }
//
//     private void Update()
//     {
//         if (Time.time - _lastComboTime > _maxTimeBetweenCombos)
//         {
//             _comboCounter = 0;
//         }
//     }
// }