using UnityEngine;
using UnityEngine.UI;
using DamageNumbersPro;

public class ComboCounter : MonoBehaviour
{
    private int _comboCounter = 0;
    [SerializeField] private float _maxTimeBetweenCombos = 2.0f;
    private float _lastComboTime = 0.0f;
    [SerializeField] private DamageNumber _damageNumbers;
    [SerializeField] private RectTransform _rect;
    public bool isStarting = true;
    

    public void IncreaseCombo()
    {
        if (isStarting)
            return;
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
            //Spawn new popup with a random number between 0 and 100.
            DamageNumber damageNumber = _damageNumbers.Spawn(Vector3.zero, 1);

            // //Set the rect parent and anchored position.
             damageNumber.SetAnchoredPosition(_rect, new Vector2(0, 0));
            // _damageNumbers.Display(_comboCounter.ToString(), transform.position);
        }
    }

    private void Update()
    {
        if (isStarting)
            return;
        
        if (Time.time - _lastComboTime > _maxTimeBetweenCombos)
        {
            _comboCounter = 0;
        }
    }
}