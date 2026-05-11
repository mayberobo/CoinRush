using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Counter : MonoBehaviour
{

    public float counter = 0;
    public TextMeshPro CounterText;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        CounterText.text = Mathf.Round(counter) + "s";

    }
}
