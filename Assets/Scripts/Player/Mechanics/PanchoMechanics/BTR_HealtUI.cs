using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTR_HealtUI : MonoBehaviour
{ 
    public Image saludUI;
    // Start is called before the first frame update
    public void DisplayHealth(float valor)
    {
        valor /= 100.0f;

        if (valor < 0f)
        {
            valor = 0f;
        }

        saludUI.fillAmount = valor;
    }
}
