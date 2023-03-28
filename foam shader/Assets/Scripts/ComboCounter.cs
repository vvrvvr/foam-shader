using UnityEngine;
using UnityEngine.UI;
using DamageNumbersPro;

public class ComboCounter : MonoBehaviour
{
    private int _comboCounter = 0;
    [SerializeField] private float _maxTimeBetweenCombos = 2.0f;
    private float _lastComboTime = 0.0f;
    [SerializeField] private DamageNumber _damageNumbers;
    [SerializeField] private DamageNumber[] phrases = new DamageNumber[0];
    [SerializeField] private RectTransform phraseRect;
    [SerializeField] private RectTransform _rect;
    [SerializeField] private float chancePercent = 100f;
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
            if (Probability(chancePercent))
            {
                DamageNumber phraseN = RandomArrayElement(phrases).Spawn(Vector3.zero);
                phraseN.SetAnchoredPosition(phraseRect, new Vector2(0, 0));
            }
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
    
    private bool Probability(float percent)
    {
        float randomValue = Random.Range(0f, 1f); // генерируем случайное значение между 0 и 1
        return randomValue <= percent / 100f; // возвращаем true, если случайное значение меньше или равно проценту
    }
    
    private DamageNumber RandomArrayElement(DamageNumber[] arr)
    {
        int randomIndex = Random.Range(0, arr.Length); // генерируем случайный индекс в диапазоне от 0 до длины массива - 1
        return arr[randomIndex]; // возвращаем элемент массива по случайному индексу
    }
}