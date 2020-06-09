using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public static bool isStart = false;
    Button b;
    // Start is called before the first frame update
    void Start()
    {
        b = gameObject.GetComponent<Button>();
        b.onClick.AddListener(ButtonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ButtonClicked()
    {
        isStart = true;
        b.gameObject.SetActive(false);
    }
}
