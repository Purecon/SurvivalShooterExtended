using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameSettings : MonoBehaviour
{
    public Text playerName;
    public InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playerName.text = ScoreManager.playerName;
    }

    public void ChangeName()
    {
        ScoreManager.playerName = inputField.textComponent.text;
    }
}
