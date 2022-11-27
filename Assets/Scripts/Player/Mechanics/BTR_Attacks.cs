using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BTR_Attacks : MonoBehaviour
{
    [Header("HabilidadesUI")]
    public BTR_DelayUI[] delayUI;

    [Header("Colliders")]
    public BoxCollider punchArea;
    public SphereCollider spinArea;

    [Header("Punch")]
    public BTR_AttackStats punchStats;
    public float timeBetweenPunches = 0.5f;

    [Header("Spin")]
    public BTR_AttackStats spinStats;
    public float spinCooldown = 5f;
    public bool spinUnlocked;
    public bool superSpinUnlocked;
    public float superSpinDamage = 0.05f;

    [Header("Shoot")]
    public float shootCooldown = 8f;
    public bool shootUnlocked;
    public bool superShootUnlocked;

    [Header("Berserk")]
    public float berserkCooldown = 30f;
    public bool berserkUnlocked;
    public float timeOnBerserk = 10f;
    public float damageModifier = 1.5f;


    private BTR_InputManager inputManager;
    private BTR_Movement movement;
    private BTR_ShootPlayer shootPlayer;
    public BTR_XpManager Xp;

    private bool punching;
    private bool performingAction;

    private float spinTimer;
    private float shootTimer;
    private float berserkTimer;
    private float currentSpeedMod = 1f;
    private float ogSpeed;

    private Animator playerAnim;
    private void Awake()
    {
        Xp = GetComponent<BTR_XpManager>();
        inputManager = FindObjectOfType<BTR_InputManager>();
        movement = FindObjectOfType<BTR_Movement>();
        shootPlayer = FindObjectOfType<BTR_ShootPlayer>();
        playerAnim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        spinTimer = Time.time;
        shootTimer = Time.time;
        berserkTimer = Time.time;
        ogSpeed = movement.speed;
    }

    void Update()
    {
        if (!performingAction)
            checkForActions();
    }

    void checkForActions()
    {
        if (inputManager.wantsToBerserk && berserkUnlocked)
            Berserk();
        else if (inputManager.wantsToSpin && spinUnlocked)
            Spin();
        else if (inputManager.wantsToShoot && shootUnlocked)
            Shoot();
        else if (inputManager.wantsToPunch)
            Punch();
    }

    void Punch()
    {
        if (!punching)
            StartCoroutine(PunchCouroutine());
    }
    IEnumerator PunchCouroutine()
    {
        performingAction = true;
        punchArea.enabled = true;
        punching = true;
        playerAnim.SetBool("Punch", true);
        yield return new WaitForSeconds(timeBetweenPunches);
        punchArea.enabled = false;
        punching = false;
        yield return new WaitForSeconds(timeBetweenPunches);
        performingAction = false;
        playerAnim.SetBool("Punch", false);
    }

    void Spin()
    {
        inputManager.wantsToSpin = false;

        if (superSpinUnlocked)
        {
            spinStats.damage = superSpinDamage;
            spinStats.SpinArea.radius = 2f;
        }

        if (Time.time - spinTimer >= spinCooldown)
        {
            Xp.XP -= 40;
            delayUI[0].activteDelay(spinCooldown);
            spinTimer = Time.time;
            StartCoroutine(SpinCouroutine());
        }
    }
    IEnumerator SpinCouroutine()
    {
        currentSpeedMod *= 1.5f;
        UpdateSpeed();
        performingAction = true;
        spinArea.enabled = true;
        playerAnim.SetBool("Spin", true);

        yield return new WaitForSeconds(1.5f);

        spinArea.enabled = false;
        currentSpeedMod /= 1.5f;
        UpdateSpeed();

        yield return new WaitForSeconds(0.5f);
        playerAnim.SetBool("Spin", false);
        performingAction = false;
    }

    void Shoot()
    {
        inputManager.wantsToShoot = false;

        if (Time.time - shootTimer >= shootCooldown)
        {
            Xp.XP -= 30;
            delayUI[1].activteDelay(shootCooldown);
            shootTimer = Time.time;
            StartCoroutine(ShootCouroutine());
        }
    }

    IEnumerator ShootCouroutine()
    {
        performingAction = true;

        if (superShootUnlocked)
        {
            shootPlayer.multishoot();
        }
        else
        {
            shootPlayer.shooting();
        }
        
        playerAnim.SetBool("Shoot", true);


        yield return new WaitForSeconds(1.5f);

        performingAction = false;
        playerAnim.SetBool("Shoot", false);

    }

    void Berserk()
    {
        inputManager.wantsToBerserk = false;

        if (Time.time - berserkTimer >= berserkCooldown)
        {
            Xp.XP -= 60;
            delayUI[2].activteDelay(berserkCooldown);
            berserkTimer = Time.time;
            StartCoroutine(BerserkCouroutine());
        }
    }

    IEnumerator BerserkCouroutine()
    {
        currentSpeedMod *= 2f;
        UpdateSpeed();
        timeBetweenPunches = 0.2f;
        punchStats.damage *= damageModifier;
        performingAction = true;

        yield return new WaitForSeconds(1f);

        performingAction = false;

        yield return new WaitForSeconds(timeOnBerserk);

        currentSpeedMod /= 2f;
        UpdateSpeed();
        timeBetweenPunches = 0.5f;
        punchStats.damage /= damageModifier;
    }

    void UpdateSpeed()
    {
        movement.speed = ogSpeed * currentSpeedMod;
    }
}