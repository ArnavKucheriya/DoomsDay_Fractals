using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Explorer : MonoBehaviour
{
    public Material mat;
    public Vector2 pos;
    public float scale, angle, color, colorSpeed, colorRepeat;
    public float leafsBoolean, juliaBoolean, linearBoolean, doubleBoolean;
    public float symmetry, symmetryx4, symmetryx8, iterations;
    public float escapeRadius, rotationSpeed, juliaSeedX, juliaSeedY;
    public float doublePwr, thirdPwr, fourthPwr, fifthPwr, sixthPwr;
    public TMP_Text valueTextIter, scaleText, posText, seedTextX, seedTextY;

    public Toggle symmetryx4Toggle;
    public Toggle symmetryx8Toggle;
    public Toggle leafsToggle;
    public Toggle juliaToggle;
    public Toggle linearToggle;
    public Toggle doubleExpToggle;
    public Toggle doublePwrToggle;
    public Toggle thirdPwrToggle;
    public Toggle fourthPwrToggle;
    public Toggle fifthPwrToggle;
    public Toggle sixthPwrToggle;

    public Slider[] sliders;

    private Vector2 smoothPos;
    private float smoothScale, smoothAngle;

    InputManager inputManager; 

    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
    }

    private void UpdateShader() 
    {
        smoothPos = Vector2.Lerp(smoothPos, pos, .03f);
        smoothScale = Mathf.Lerp(smoothScale, scale, .03f);
        smoothAngle = Mathf.Lerp(smoothAngle, angle, .03f);

        float aspect = (float)Screen.width / (float)Screen.height;
        float scaleX = smoothScale;
        float scaleY = smoothScale;

        if (aspect > 1f)
        {
            scaleY /= aspect;
        }
        else
        {
            scaleX *= aspect;
        }

        mat.SetVector("_Area", new Vector4(smoothPos.x, smoothPos.y, scaleX, scaleY));
        mat.SetFloat("_Angle", smoothAngle);
        mat.SetFloat("_Color", color);
        mat.SetFloat("_ColorSpeed", colorSpeed);
        mat.SetFloat("_MaxIter", iterations);
        mat.SetFloat("_LeafsBoolean", leafsBoolean);
        mat.SetFloat("_JuliaBoolean", juliaBoolean);
        mat.SetFloat("_LinearBoolean", linearBoolean);
        mat.SetFloat("_DoubleBoolean", doubleBoolean);
        mat.SetFloat("_ColorRepeat", colorRepeat);
        mat.SetFloat("_EscapeRadius", escapeRadius);
        mat.SetFloat("_RotationSpeed", rotationSpeed);
        mat.SetFloat("_Symmetry", symmetry);
        mat.SetFloat("_Symmetryx4", symmetryx4);
        mat.SetFloat("_Symmetryx8", symmetryx8);
        mat.SetFloat("_JuliaSeedX", juliaSeedX);
        mat.SetFloat("_JuliaSeedY", juliaSeedY);
        mat.SetFloat("_DoublePwr", doublePwr);
        mat.SetFloat("_ThirdPwr", thirdPwr);
        mat.SetFloat("_FourthPwr", fourthPwr);
        mat.SetFloat("_FifthPwr", fifthPwr);
        mat.SetFloat("_SixthPwr", sixthPwr);
    }

    private void HandleInputs() 
    {
        if (inputManager.GetButton("Zoom In")) 
        {
            scale *= .99f;
        }
        if (inputManager.GetButton("Zoom Out"))
        {
            scale *= 1.01f;
        }
        if (inputManager.GetButton("Rotate Right"))
        {
            angle -= .01f; 
        }
        if (inputManager.GetButton("Rotate Left"))
        {
            angle += .01f;
        }

        Vector2 dir = new Vector2(.01f * scale, 0);
        float s = Mathf.Sin(angle);
        float c = Mathf.Cos(angle);
        dir = new Vector2(dir.x * c, dir.x * s);

        if (inputManager.GetButton("Move Left"))
        {
            pos -= dir;
        }
        if (inputManager.GetButton("Move Right"))
        {
            pos += dir;
        }

        dir = new Vector2(-dir.y, dir.x);

        if (inputManager.GetButton("Move Down"))
        {
            pos -= dir;
        }
        if (inputManager.GetButton("Move Up"))
        {
            pos += dir;
        }
    }

    void FixedUpdate()
    {
        scaleText.text = "Scale: " + smoothScale;
        posText.text = "X: " + smoothPos.x + "\tY: " + smoothPos.y;

        HandleInputs();
        UpdateShader();
    }

    public void AdjustColor(float newcolor) 
    {
        color = newcolor;            
    }

    public void AdjustColorSpeed(float newColorSpeed)
    {
        colorSpeed = newColorSpeed;
    }

    public void AdjustIterations(float newiterations)
    {
        iterations = newiterations;
        valueTextIter.text = Mathf.RoundToInt(newiterations) + " Iterations";
    }

    public void AdjustColorRepeat(float newColorRepeat)
    {
        colorRepeat = newColorRepeat;
    }

    public void AdjustEscapeRadius(float newEscapeRadius)
    {
        escapeRadius = newEscapeRadius;
    }

    public void AdjustRotationSpeed(float newRotationSpeed)
    {
        rotationSpeed = newRotationSpeed;
    }

    public void AdjustSymmetryx4Toggle()
    {
        if (symmetryx4Toggle.isOn)
        {
            symmetry = 1;
            symmetryx4 = 1;
            symmetryx8 = 0;
            symmetryx8Toggle.isOn = false;
        }
        else if (symmetryx8Toggle.isOn)
        {
            symmetryx8 = 1;
            symmetryx4 = 0;
            symmetry = 1;
        }
        else
        {
            symmetry = 0;
        }
    }

    public void AdjustSymmetryx8Toggle()
    {
        if (symmetryx8Toggle.isOn)
        {
            symmetry = 1;
            symmetryx8 = 1;
            symmetryx4 = 0;
            symmetryx4Toggle.isOn = false;
        }
        else if (symmetryx4Toggle.isOn)
        {
            symmetryx4 = 1;
            symmetryx8 = 0;
            symmetry = 1;
        }
        else
        {
            symmetry = 0;
        }
    }

    public void AdjustLinearToggle()
    {
        if (linearToggle.isOn)
        {
            linearBoolean = 1;
            doubleExpToggle.isOn = false;
        }
        else
        {
            linearBoolean = 0;
        }
    }

    public void AdjustDoubleExpToggle()
    {
        if (doubleExpToggle.isOn)
        {
            doubleBoolean = 1;
            linearToggle.isOn = false;
        }
        else
        {
            doubleBoolean = 0;
        }
    }

    public void AdjustLeafsToggle()
    {
        if (leafsToggle.isOn)
        {
            leafsBoolean = 1;
        }
        else
        {
            leafsBoolean = 0;
        }
    }

    public void ThirdPwrToggle()
    {
        if (thirdPwrToggle.isOn)
        {
            thirdPwr = 1;
            doublePwr = 0;
            fourthPwr = 0;
            fifthPwr = 0;
            sixthPwr = 0;
            doublePwrToggle.isOn = false;
            fourthPwrToggle.isOn = false;
            fifthPwrToggle.isOn = false;
            sixthPwrToggle.isOn = false;
        }
        else
        {
            thirdPwr = 0;
        }
    }

    public void FourthPwrToggle()
    {
        if (fourthPwrToggle.isOn)
        {
            doublePwr = 0;
            fourthPwr = 1;
            thirdPwr = 0;
            fifthPwr = 0;
            sixthPwr = 0;
            doublePwrToggle.isOn = false;
            thirdPwrToggle.isOn = false;
            fifthPwrToggle.isOn = false;
            sixthPwrToggle.isOn = false;
        }
        else
        {
            fourthPwr = 0;
        }
    }

    public void FifthPwrToggle()
    {
        if (fifthPwrToggle.isOn)
        {
            doublePwr = 0;
            fifthPwr = 1;
            thirdPwr = 0;
            fourthPwr = 0;
            sixthPwr = 0;
            doublePwrToggle.isOn = false;
            fourthPwrToggle.isOn = false;
            thirdPwrToggle.isOn = false;
            sixthPwrToggle.isOn = false;
        }
        else
        {
            fifthPwr = 0;
        }
    }

    public void SixthPwrToggle()
    {
        if (sixthPwrToggle.isOn)
        {
            doublePwr = 0;
            sixthPwr = 1;
            thirdPwr = 0;
            fourthPwr = 0;
            fifthPwr = 0;
            doublePwrToggle.isOn = false;
            fourthPwrToggle.isOn = false;
            fifthPwrToggle.isOn = false;
            thirdPwrToggle.isOn = false;
        }
        else 
        {
            sixthPwr = 0;
        }
    }

    public void DoublePwrToggle()
    {
        if (doublePwrToggle.isOn)
        {
            doublePwr = 1;
            sixthPwr = 0;
            thirdPwr = 0;
            fourthPwr = 0;
            fifthPwr = 0;
            thirdPwrToggle.isOn = false;
            fourthPwrToggle.isOn = false;
            fifthPwrToggle.isOn = false;
            sixthPwrToggle.isOn = false;
        }
        else
        {
            doublePwr = 0;
        }
    }

    public void AdjustJuliaToggle()
    {
        if (juliaToggle.isOn)
        {
            juliaBoolean = 1;
        }
        else
        {
            juliaBoolean = 0;
        }
    }

    public void AdjustJuliaSeedX(float newJuliaSeedX)
    {
        juliaSeedX = newJuliaSeedX;
        seedTextX.text = "Seed X: " + (newJuliaSeedX);
    }

    public void AdjustJuliaSeedY(float newJuliaSeedY)
    {
        juliaSeedY = newJuliaSeedY;
        seedTextY.text = "Seed Y: " + (newJuliaSeedY);
    }

    public void ClickReset()
    {
        pos.x = 0.0f;
        pos.y = 0.0f;
        scale = 5.0f;
        angle = 0.0f;
        smoothPos = Vector2.Lerp(smoothPos, pos, .03f);
        smoothScale = Mathf.Lerp(smoothScale, scale, .03f);
        smoothAngle = Mathf.Lerp(smoothAngle, angle, .03f);
        color = 0.0f;
        colorRepeat = 0.7333333f;
        colorSpeed = 0.0f;
        rotationSpeed = 0.0f;
        escapeRadius = 4.0f;
        leafsBoolean = 0;
        leafsToggle.isOn = false;
        symmetry = 0;
        symmetryx4Toggle.isOn = false;
        symmetryx8Toggle.isOn = false;
        linearBoolean = 0;
        linearToggle.isOn = false;
        doubleBoolean = 1;
        doubleExpToggle.isOn = true;
        juliaSeedX = -0.79f;
        juliaSeedY = 0.15f;
        iterations = 255;

        sliders[0].value = 0.0f;
        sliders[1].value = 0.7333333f;
        sliders[2].value = 0.0f;
        sliders[3].value = 0.0f;
        sliders[4].value = 4.0f;
        sliders[5].value = 255;
        sliders[6].value = -0.79f;
        sliders[7].value = 0.15f;
    }
}
