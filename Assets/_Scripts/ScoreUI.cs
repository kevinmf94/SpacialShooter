using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.text = ScoreManager.Instance.Amount.ToString();
    }
}
