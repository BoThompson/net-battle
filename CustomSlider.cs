using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomSlider : MonoBehaviour
{
    public Slider slider;
    public GameObject customFlag;
    public float Value
    {
        get
        {
            return slider.value;
        }

        set
        {
            slider.value = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        BattleManager.Instance.CustomSlider = this;
    }


    // Update is called once per frame
    void Update()
    {
        if(BattleManager.Instance.State == GameState.Battle
        && slider.value < 1)
        {
            slider.value = Mathf.Min(1, Value + BattleManager.Instance.CustomFillSpeed * Time.deltaTime);
        }
        if (BattleManager.Instance.State == GameState.Menu || slider.value < 1)
            customFlag.SetActive(false);
        else
            customFlag.SetActive(true);
    }
}
