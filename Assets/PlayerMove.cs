using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] public GameObject p1;
    [SerializeField] public GameObject p2;
    [SerializeField] private PlayerMove p1PlayerMove;
    [SerializeField] private PlayerMove p2PlayerMove;
    [SerializeField] private AttackHit attackHit;
    [SerializeField] private BlockHit blockHit;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 mover;
    [SerializeField] private float blockTimer;
    [SerializeField] private float hp;
    [SerializeField] private bool blockTimerCheck;
    [SerializeField] private float cooldown;
    [SerializeField] private bool busy;
    [SerializeField] private bool animBusy;
    [SerializeField] private float animCooldown;
    [SerializeField] private bool gameStarted;
    [SerializeField] private UI ui;
    [SerializeField] public GameObject main;
    [SerializeField] private bool P1Connected;
    [SerializeField] private bool P2Connected;
    [SerializeField] private bool p1HBlocked;
    [SerializeField] private bool p2HBlocked;
    [SerializeField] private bool p1LBlocked;
    [SerializeField] private bool p2LBlocked;
    [SerializeField] public int playerIndex;
    [SerializeField] private Animator animator;
    [SerializeField] private float HattackHitStarter;
    [SerializeField] private float LattackHitStarter;
    [SerializeField] private bool HattackHitCheck;
    [SerializeField] private bool LattackHitCheck;
    [SerializeField] public Slider p1Slider;
    [SerializeField] public Slider p2Slider;
    

    void Start()
    {
        cooldown = 0f;
        animCooldown = 0f;
        hp = 5f;
        p1HBlocked = false;
        p2HBlocked = false;
        p1LBlocked = false;
        p2LBlocked = false;
        blockTimerCheck = false;
        HattackHitStarter = 0f;
        LattackHitStarter = 0f;
        HattackHitCheck = false;
        LattackHitCheck = false;
        blockTimer = 0f;
        animator = gameObject.transform.GetChild(4).GetComponent<Animator>();
        P1Connected = false;
        P2Connected = false;
        gameStarted = false;
        p1PlayerMove = p1.GetComponent<PlayerMove>();
        p2PlayerMove = p2.GetComponent<PlayerMove>();
        ui = main.GetComponent<UI>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        attackHit = gameObject.transform.GetChild(0).GetComponent<AttackHit>();
        blockHit = gameObject.transform.GetChild(2).GetComponent<BlockHit>();
        busy = false;
    }
    public void RoundStart()
    {
        gameStarted = true;
    }
    public bool P1Player()
    {
        if(playerIndex == 0)
        {
            if(P1Connected)
                return true;
            return false;
        }
        return false;
    }
    public bool P2Player()
    {
        if(playerIndex == 1)
        {
            if(P2Connected)
                return true;
            return false;
        }
        return false;
    }
    public int GetPlayerIndex()
    {
        return playerIndex;
    }
    public void Moving(Vector2 moveDirection)
    {
        if(gameStarted)
        {
            mover = moveDirection;
        }
    }
    public void AttackHigh()
    {
        if(gameStarted)
        {
            animator.SetTrigger("attackhigh");
            HattackHitStarter = 5/12f;
            HattackHitCheck = true;
            busy = true;
            animBusy = true;
            animator.SetBool("busy", animBusy);
            cooldown = 5/6f;
            animCooldown = 5/6f;
        }
    }
    public void AttackLow()
    {
        if(playerIndex == 0)
        {
            P1Connected = true;
        }
        if(playerIndex == 1)
        {
            P2Connected = true;
        }
        if(gameStarted)
        {
            animator.SetTrigger("attacklow");
            LattackHitStarter = 5/12f;
            LattackHitCheck = true;
            busy = true;
            animBusy = true;
            animator.SetBool("busy", animBusy);
            cooldown = 5/6f;
            animCooldown = 5/6f;
        }
    }
    public void BlockHigh()
    {
        if(gameStarted)
        {
            if(playerIndex == 0)
            {
                if(blockHit.P1Block() && p2PlayerMove.IsHAttacking())
                {
                    p1HBlocked = true;
                    blockTimer = 1.2f;
                    blockTimerCheck = true;
                }
            }
            if(playerIndex == 1)
            {
                if(blockHit.P2Block() && p1PlayerMove.IsHAttacking())
                {
                    p2HBlocked = true;
                    blockTimer = 1.2f;
                    blockTimerCheck = true;
                }
            }
            animator.SetTrigger("blockhigh");
            Debug.Log("p1" + p1HBlocked);
            Debug.Log("p2" + p2HBlocked);
            busy = true;
            animBusy = true;
            animator.SetBool("busy", animBusy);
            cooldown = 2/3f;
            animCooldown = 2/3f;
        }
    }
    public void BlockLow()
    {
        if(gameStarted)
        {
            if(playerIndex == 0)
            {
                if(blockHit.P1Block() && p2PlayerMove.IsLAttacking())
                {
                    p1LBlocked = true;
                    blockTimer = 1.2f;
                    blockTimerCheck = true;
                }
            }
            if(playerIndex == 1)
            {
                if(blockHit.P2Block() && p1PlayerMove.IsLAttacking())
                {
                    p2LBlocked = true;
                    blockTimer = 1.2f;
                    blockTimerCheck = true;
                }
            }
            animator.SetTrigger("blocklow");
            Debug.Log("p1" + p1LBlocked);
            Debug.Log("p2" + p2LBlocked);
            busy = true;
            animBusy = true;
            animator.SetBool("busy", animBusy);
            cooldown = 2/3f;
            animCooldown = 2/3f;
        }
    }
    public bool IsHBlocking()
    {
        if(playerIndex == 0)
        {
            return p1HBlocked;
        }
        if(playerIndex == 1)
        {
            return p2HBlocked;
        }
        return false;
    }
    public bool IsLBlocking()
    {
        if(playerIndex == 0)
        {
            return p1LBlocked;
        }
        if(playerIndex == 1)
        {
            return p2LBlocked;
        }
        return false;
    }
    public void GotHit(float dmg)
    {
        hp -= dmg;
        if(playerIndex == 0)
        {
            p1Slider.value = hp;
        }
        if(playerIndex == 1)
        {
            p2Slider.value = hp;
        }
    }
    public bool IsHAttacking()
    {
        return HattackHitCheck;
    }
    public bool IsLAttacking()
    {
        return LattackHitCheck;
    }
    public bool IsBusy()
    {
        return busy;
    }
    public void Pauser()
    {
        if(gameStarted)
        {
            ui.Pause();
        }
    }
    void Update()
    {
        if(hp <= 0)
        {
            if(playerIndex == 0)
            {
                ui.P2Win();
            }
            if(playerIndex == 1)
            {
                ui.P1Win();
            }
        }
        blockTimer -= Time.deltaTime;
        if(blockTimer <= 0 && blockTimerCheck == true)
        {
            Debug.Log(blockTimer);
            blockTimerCheck = false;
            blockTimer = 0;
            if(playerIndex == 0)
            {
                p1HBlocked = false;
            }
            if(playerIndex == 1)
            {
                p2HBlocked = false;
            }
            if(playerIndex == 0)
            {
                p1LBlocked = false;
            }
            if(playerIndex == 1)
            {
                p2LBlocked = false;
            }
        }
        cooldown -= Time.deltaTime;
        if(0f >= cooldown)
        {
            rb.velocity = new Vector2(mover.x*5f, 0f);
            if(mover.x == 0)
            {
                animator.SetBool("walking 0", false);
                animator.SetBool("walk back 0", false);
            }
            else if(mover.x > 0)
            {
                animator.SetBool("walking 0", true);
                animator.SetBool("walk back 0", false);
            }
            else if(mover.x < 0)
            {
                animator.SetBool("walking 0", false);
                animator.SetBool("walk back 0", true);
            }
            busy = false;
            cooldown = 0;
        }
        else
        {
            rb.velocity = new Vector2(0, 0f);
            animator.SetBool("walking 0", false);
            animator.SetBool("walk back 0", false);
        }
        animCooldown -= Time.deltaTime;
        if(animCooldown <= 0f)
        {
            animCooldown = 0f;
            animBusy = false;
            animator.SetBool("busy", animBusy);
        }
        HattackHitStarter -= Time.deltaTime;
        if(HattackHitStarter <= 0 && HattackHitCheck)
        {
            HattackHitStarter = 0;
            HattackHitCheck = false;
            if(playerIndex == 0)
            {
                if(attackHit.P1Hit())
                {
                    if(p2PlayerMove.IsHBlocking())
                    {
                        Debug.Log("p2HBlocked");
                        cooldown = 1.2f;
                    }
                    else
                    {
                        Debug.Log("p1Win");
                        p2PlayerMove.GotHit(1f);
                    }
                }
            }
            if(playerIndex == 1)
            {
                if(attackHit.P2Hit())
                {
                    if(p1PlayerMove.IsHBlocking())
                    {
                        Debug.Log("p1HBlocked");
                        cooldown = 1.2f;
                    }
                    else
                    {
                        Debug.Log("p2Win");
                        p1PlayerMove.GotHit(1f);
                    }
                }
            }
        }
        LattackHitStarter -= Time.deltaTime;
        if(LattackHitStarter <= 0 && LattackHitCheck)
        {
            LattackHitStarter = 0;
            LattackHitCheck = false;
            if(playerIndex == 0)
            {
                if(attackHit.P1Hit())
                {
                    if(p2PlayerMove.IsLBlocking())
                    {
                        Debug.Log("p2LBlocked");
                        cooldown = 1.2f;
                    }
                    else
                    {
                        Debug.Log("p1Hit");
                        p2PlayerMove.GotHit(1f);
                    }
                }
            }
            if(playerIndex == 1)
            {
                if(attackHit.P2Hit())
                {
                    if(p1PlayerMove.IsLBlocking())
                    {
                        Debug.Log("p1LBlocked");
                        cooldown = 1.2f;
                    }
                    else
                    {
                        Debug.Log("p2Win");
                        p1PlayerMove.GotHit(1f);
                    }
                }
            }
        }
    }
}
