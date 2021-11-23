using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomeScript : MonoBehaviour {

    public int i; // если не указать вид доступа, то будет по умолчанию private

    [SerializeField] // означает, что переменная будет отображаться в Unity, но будет иметь доступ private
    private int j = 100;

    [SerializeField]
    private float q = 23.45f;

    public void Start() // При старте игры
    {
        print("Game is started");
        Show(); // вызов  функции Show()
    }

    public void FixedUpdate() // срабатывает каждые 0,02 секунды. Используется при работе с физикой
    {
        Debug.Log("Fixed Update : " + Time.deltaTime); // Debug.Log аналогичен print
                                                       // Time.deltaTime- время между Frame-мами, которое прошло
    }

    public void Update() // Обновляется с каждым новым Frame
    {
        Debug.Log("Update Time : " + Time.deltaTime);
    }

    void Show() // создание собственной функции. Вызвать функцию Show() возможно только во встроенной функции Start()
    {
        print(q);
    }

}
