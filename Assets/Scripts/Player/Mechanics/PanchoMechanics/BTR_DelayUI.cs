using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BTR_DelayUI : MonoBehaviour
{
    private Image imagenHabilidad;
    private Text textoDelay;
    private Color orginialColor;

    // Start is called before the first frame update
    void Start()
    {
        imagenHabilidad = GetComponentInChildren<Image>();
        textoDelay = GetComponentInChildren<Text>();
        textoDelay.enabled = false;
        orginialColor = imagenHabilidad.color;
        imagenHabilidad.color = new Color(1f,1f,1f,0.4f);
    }
    public void activteDelay(float canUse) { 
        imagenHabilidad.color = new Color(1f,1f,1f,0.4f);
        textoDelay.enabled = true;
        float canUseDelay = canUse;
        StartCoroutine("finishDelay", canUseDelay);

    }

    private IEnumerator finishDelay(float canUseDelay)
    {
        while(canUseDelay > 0)
        {
            textoDelay.text = "" + canUseDelay;
            canUseDelay--;
            yield return new WaitForSeconds(1.0f);
        }
        textoDelay.enabled = false;
        imagenHabilidad.color = orginialColor;
    }
}
