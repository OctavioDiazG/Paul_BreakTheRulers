using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTR_XpManager : MonoBehaviour
{
    public int XP;
    public int XPtoSpin = 30;
    public int XPtoShot = 150;
    public int XPtoBerserk = 300;
    public int XPtoSuperSpin = 500;
    public int XPtoSuperShot = 800;

    private BTR_Attacks attacks;

    private void Start()
    {
        attacks = FindObjectOfType<BTR_Attacks>();
    }

    public void addXP(int newXP)
    {
        XP += newXP;
        CheckUnlocks();
    }

    void CheckUnlocks()
    {
        if (XP >= XPtoSpin) //Desbloquear Spin
        {
            attacks.spinUnlocked = true;
        }

        if (XP >= XPtoShot) //Desbloquear Slingshot
        {
            attacks.shootUnlocked = true;
        }

        if (XP >= XPtoBerserk) //Desbloquear Berserk
        {
            attacks.berserkUnlocked = true;
        }

        if (XP >= XPtoSuperSpin) //Desbloquear SuperSpin
        {
            attacks.superSpinUnlocked = true;
        }

        if (XP >= XPtoSuperShot) //Desbloquear SuperShot
        {
            attacks.superShootUnlocked = true;
        }
    }
}