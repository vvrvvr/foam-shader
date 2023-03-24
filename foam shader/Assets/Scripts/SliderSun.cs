using UnityEngine;
using UnityEngine.UI;

public class SliderSun : MonoBehaviour
{
    public Slider slider;
    public Transform targetObject;
    public float minRotation = -180f;
    public float maxRotation = 180f;
    private float rotX, rotZ;

    private float startRotation;

    void Start()
    {
        // Запоминаем начальное положение объекта
        startRotation = targetObject.rotation.eulerAngles.y;
        rotX = targetObject.rotation.eulerAngles.x;
        rotZ = targetObject.rotation.eulerAngles.z;

        // Устанавливаем слайдер в среднее положение
        slider.value = 0.5f;
    }

    void Update()
    {
        // Вычисляем значение поворота в градусах на основе положения слайдера
        float rotation = Mathf.Lerp(minRotation, maxRotation, slider.value);

        // Поворачиваем объект вокруг оси Y
        targetObject.rotation = Quaternion.Euler(rotX, startRotation + rotation, rotZ);
    }
}