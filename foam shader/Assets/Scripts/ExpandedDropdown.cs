using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExpandedDropdown : TMP_Dropdown
{
    public int defaultIndex = 0;

    protected override void Start()
    {
        base.Start();

        // Устанавливаем значение выбранного элемента
        value = defaultIndex;

        // Разворачиваем элемент Dropdown
        Show();

        // Отключаем возможность изменения выбора пользователем
        interactable = false;

        // Обновляем отображение значения и настраиваем шаблон Dropdown
        RefreshShownValue();
    }
}

