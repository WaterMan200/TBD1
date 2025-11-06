using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private KeyValuePair<string, int> randomEntry1;
    [SerializeField] private KeyValuePair<string, int> randomEntry2;
    [SerializeField] private KeyValuePair<string, int> randomEntry3;
    [SerializeField] private Dictionary<string, int> myDictionary = new Dictionary<string, int>();
    [SerializeField] public GameObject p1;
    [SerializeField] public GameObject p2;
    [SerializeField] public TextMeshProUGUI card1;
    [SerializeField] public TextMeshProUGUI card2;
    [SerializeField] public TextMeshProUGUI card3;
    [SerializeField] private PlayerMove p1PlayerMove;
    [SerializeField] private PlayerMove p2PlayerMove;
    [SerializeField] private AttackHit attackHit;
    [SerializeField] public GameObject HblockPlayerTrigger;
    [SerializeField] public GameObject LblockPlayerTrigger;
    [SerializeField] private HBlockHit HblockHit;
    [SerializeField] private LBlockHit LblockHit;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 mover;
    [SerializeField] private float blockTimer;
    [SerializeField] private float hp;
    [SerializeField] private float hpMax;
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
    [SerializeField] private float HblockTimerTwo;
    [SerializeField] private bool HblockTimerCheckTwo;
    [SerializeField] private float LblockTimerTwo;
    [SerializeField] private bool LblockTimerCheckTwo;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float regen;
    [SerializeField] private float NoMoveRegen;
    [SerializeField] private float regenTime;
    [SerializeField] private bool dictionaryAdded = false;
    [SerializeField] private float cooldownReduction;
    [SerializeField] private float stunTimer;
    [SerializeField] private float range;
    [SerializeField] private int roundsWon;
    [SerializeField] public TextMeshProUGUI roundsWonText;
    [SerializeField] private CapsuleCollider2D HAttackCollider;
    [SerializeField] private CapsuleCollider2D LAttackCollider; 
    [SerializeField] private float jumpForce;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public Transform groundCheck;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float moveSlow;
    [SerializeField] private float slowTimer;
    [SerializeField] private bool slowTimerBool;
    [SerializeField] private float oldSpeed;

    public void Start()
    {
        if (dictionaryAdded == false)
        {
            myDictionary = new Dictionary<string, int>();
            roundsWon = 0;
            speed = 5f;
            oldSpeed = speed;
            damage = 1f;
            hpMax = 5f;
            regen = 0;
            NoMoveRegen = 0;
            cooldownReduction = 0;
            stunTimer = 1.2f;
            range = 0f;
            myDictionary.Add("Damage", 0);
            myDictionary.Add("Health", 1);
            myDictionary.Add("Speed", 2);
            myDictionary.Add("Regen", 3);
            myDictionary.Add("Still\nRegen", 4);
            myDictionary.Add("Faster\nCooldown", 5);
            myDictionary.Add("Stun", 6);
            myDictionary.Add("Range", 7);
            myDictionary.Add("Slowing\nPunches", 8);
            dictionaryAdded = true;
        }
        speed = oldSpeed;
        slowTimer = 0f;
        slowTimerBool = false;
        roundsWonText.text = "" + roundsWon;
        jumpForce = 14f;
        cooldown = 0f;
        animCooldown = 0f;
        hp = hpMax;
        regenTime = 1f;
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
        HAttackCollider = gameObject.transform.GetChild(0).GetComponent<CapsuleCollider2D>();
        HAttackCollider.size = new Vector2(0.4336568f + range, 0.04112294f);
        LAttackCollider = gameObject.transform.GetChild(1).GetComponent<CapsuleCollider2D>();
        LAttackCollider.size = new Vector2(0.9560172f + range, 0.3665857f);
        ui = main.GetComponent<UI>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        attackHit = gameObject.transform.GetChild(0).GetComponent<AttackHit>();
        HblockHit = gameObject.transform.GetChild(2).GetComponent<HBlockHit>();
        LblockHit = gameObject.transform.GetChild(3).GetComponent<LBlockHit>();
        busy = false;

        animator.Play("Idle");
        if (playerIndex == 0)
        {
            gameObject.transform.position = new Vector3(-2, 0, 0);
            p1Slider.maxValue = hp;
            p1Slider.value = hp;
        }
        if (playerIndex == 1)
        {
            gameObject.transform.position = new Vector3(2, 0, 0);
            p2Slider.maxValue = hp;
            p2Slider.value = hp;
        }
    }
    public void ChangeDictionary()
    {
        dictionaryAdded = false;
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
            {
                return true;
            }
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
        if (gameStarted)
        {
            mover = moveDirection;
        }
    }
    public void Dash()
    {
        
    }
    public void Circle()
    {

    }
    public void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if(isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
            cooldown = 5/6f - cooldownReduction;
            animCooldown = 5/6f - cooldownReduction;
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
            cooldown = 5/6f - cooldownReduction;
            animCooldown = 5/6f - cooldownReduction;
        }
    }
    public void BlockHigh()
    {
        if(gameStarted)
        {
            if(playerIndex == 0)
            {
                if(HblockHit.P1Block() && p2PlayerMove.IsHAttacking())
                {
                    p1HBlocked = true;
                    blockTimer = 2/3f;
                    blockTimerCheck = true;
                }
                else
                {
                    HblockTimerTwo = .25f;
                    HblockTimerCheckTwo  = true;
                }
            }
            if(playerIndex == 1)
            {
                if(HblockHit.P2Block() && p1PlayerMove.IsHAttacking())
                {
                    p2HBlocked = true;
                    blockTimer = 2/3f;
                    blockTimerCheck = true;
                }
                else
                {
                    HblockTimerTwo = .25f;
                    HblockTimerCheckTwo  = true;
                }
            }
            animator.SetTrigger("blockhigh");
            busy = true;
            animBusy = true;
            animator.SetBool("busy", animBusy);
            cooldown = 2/3f - cooldownReduction;
            animCooldown = 2/3f - cooldownReduction;
        }
    }
    public void BlockLow()
    {
        if(gameStarted)
        {
            if(playerIndex == 0)
            {
                if(LblockHit.P1Block() && p2PlayerMove.IsLAttacking())
                {
                    p1LBlocked = true;
                    blockTimer = 2/3f;
                    blockTimerCheck = true;
                }
                else
                {
                    LblockTimerTwo = .25f;
                    LblockTimerCheckTwo  = true;
                }
            }
            if(playerIndex == 1)
            {
                if(LblockHit.P2Block() && p1PlayerMove.IsLAttacking())
                {
                    p2LBlocked = true;
                    blockTimer = 2/3f;
                    blockTimerCheck = true;
                } 
                else
                {
                    LblockTimerTwo = .25f;
                    LblockTimerCheckTwo  = true;
                }
            }
            animator.SetTrigger("blocklow");
            busy = true;
            animBusy = true;
            animator.SetBool("busy", animBusy);
            cooldown = 2/3f - cooldownReduction;
            animCooldown = 2/3f - cooldownReduction;
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
        if (gameStarted)
        {
            ui.Pause();
        }
    }
    public void CardsUI()
    {
        int randomInt1 = Random.Range(0, myDictionary.Count);
        int randomInt2 = Random.Range(0, myDictionary.Count);
        while (randomInt2 == randomInt1)
        {
            randomInt2 = Random.Range(0, myDictionary.Count);
        }
        int randomInt3 = Random.Range(0, myDictionary.Count);
        while (randomInt3 == randomInt1 || randomInt3 == randomInt2)
        {
            randomInt3 = Random.Range(0, myDictionary.Count);
        }
        foreach (KeyValuePair<string, int> kvp in myDictionary)
        {
            if (randomInt1 == kvp.Value)
                randomEntry1 = kvp;
            if (randomInt2 == kvp.Value)
                randomEntry2 = kvp;
            if (randomInt3 == kvp.Value)
                randomEntry3 = kvp;
        }
        card1.text = $"{randomEntry1.Key}";
        card2.text = $"{randomEntry2.Key}";
        card3.text = $"{randomEntry3.Key}";
    }
    public bool RoundWin()
    {
        roundsWon++;
        roundsWonText.text = "" + roundsWon;
        if (roundsWon >= 5)
        {
            if (playerIndex == 0)
            {
                ui.P1Win();
            }
            if (playerIndex == 1)
            {
                ui.P2Win();
            }
            return false;
        }
        else
        {
            return true;
        }
    }
    public void StunTime()
    {
        stunTimer += 0.3f;

    }
    public void SlowMovement(float seconds)
    {
        if (slowTimerBool == false)
            oldSpeed = speed;
        speed = speed / 2;
        slowTimer = seconds;
        slowTimerBool = true;
    }
    void Update()
    {
        slowTimer -= Time.deltaTime;
        if(slowTimerBool == true && slowTimer <= 0)
        {
            speed = oldSpeed;
            slowTimerBool = false;
        }
        if (hp <= 0)
        {
            CardsUI();
            if (playerIndex == 0)
            {
                if (p2PlayerMove.RoundWin())
                    ui.P1Round();
            }
            if (playerIndex == 1)
            {
                if (p1PlayerMove.RoundWin())
                    ui.P2Round();
            }
            hp = 1;
        }
        if (playerIndex == 0)
        {
            if (p2.transform.position.x < gameObject.transform.position.x)
            {
                Vector3 currentRotation = transform.eulerAngles;
                currentRotation.y = 180f;
                transform.eulerAngles = currentRotation;
            }
            if (p2.transform.position.x > gameObject.transform.position.x)
            {
                Vector3 currentRotation = transform.eulerAngles;
                currentRotation.y = 0f;
                transform.eulerAngles = currentRotation;
            }
        }
        if (playerIndex == 1)
        {
            if (p1.transform.position.x > gameObject.transform.position.x)
            {
                Vector3 currentRotation = transform.eulerAngles;
                currentRotation.y = 180f;
                transform.eulerAngles = currentRotation;
            }
            if (p1.transform.position.x < gameObject.transform.position.x)
            {
                Vector3 currentRotation = transform.eulerAngles;
                currentRotation.y = 0f;
                transform.eulerAngles = currentRotation;
            }
        }
        blockTimer -= Time.deltaTime;
        if (blockTimer <= 0 && blockTimerCheck == true)
        {
            blockTimerCheck = false;
            blockTimer = 0;
            if (playerIndex == 0)
            {
                p1HBlocked = false;
            }
            if (playerIndex == 1)
            {
                p2HBlocked = false;
            }
            if (playerIndex == 0)
            {
                p1LBlocked = false;
            }
            if (playerIndex == 1)
            {
                p2LBlocked = false;
            }
        }
        HblockTimerTwo -= Time.deltaTime;
        if (HblockTimerTwo <= 0 && HblockTimerCheckTwo)
        {
            HblockTimerCheckTwo = false;
            HblockTimerTwo = 0f;
            if (playerIndex == 0)
            {
                if (HblockHit.P1Block() && p2PlayerMove.IsHAttacking())
                {
                    p1HBlocked = true;
                    blockTimer = .95f;
                    blockTimerCheck = true;
                }
            }
            if (playerIndex == 1)
            {
                if (HblockHit.P2Block() && p1PlayerMove.IsHAttacking())
                {
                    p2HBlocked = true;
                    blockTimer = .95f;
                    blockTimerCheck = true;
                }
            }
        }
        LblockTimerTwo -= Time.deltaTime;
        if (LblockTimerTwo <= 0 && LblockTimerCheckTwo)
        {
            LblockTimerCheckTwo = false;
            LblockTimerTwo = 0f;
            if (playerIndex == 0)
            {
                if (LblockHit.P1Block() && p2PlayerMove.IsLAttacking())
                {
                    p1LBlocked = true;
                    blockTimer = .95f;
                    blockTimerCheck = true;
                }
            }
            if (playerIndex == 1)
            {
                if (LblockHit.P2Block() && p1PlayerMove.IsLAttacking())
                {
                    p2LBlocked = true;
                    blockTimer = .95f;
                    blockTimerCheck = true;
                }
            }
        }
        cooldown -= Time.deltaTime;
        if (0f >= cooldown)
        {
            rb.velocity = new Vector2(mover.x*speed, rb.velocity.y);

            if(mover.x == 0)
            {
                animator.SetBool("walking 0", false);
                animator.SetBool("walk back 0", false);
            }
            else if (mover.x > 0)
            {
                animator.SetBool("walking 0", true);
                animator.SetBool("walk back 0", false);
            }
            else if (mover.x < 0)
            {
                animator.SetBool("walking 0", false);
                animator.SetBool("walk back 0", true);
            }
            busy = false;
            cooldown = 0;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("walking 0", false);
            animator.SetBool("walk back 0", false);
        }
        animCooldown -= Time.deltaTime;
        if (animCooldown <= 0f)
        {
            animCooldown = 0f;
            animBusy = false;
            animator.SetBool("busy", animBusy);
        }
        HattackHitStarter -= Time.deltaTime;
        if (HattackHitStarter <= 0 && HattackHitCheck)
        {
            HattackHitStarter = 0;
            HattackHitCheck = false;
            if (playerIndex == 0)
            {
                if (attackHit.P1Hit())
                {
                    if (p2PlayerMove.IsHBlocking())
                    {
                        cooldown = stunTimer;
                    }
                    else
                    {
                        p2PlayerMove.GotHit(damage);
                        if (moveSlow > 0)
                        {
                            p2PlayerMove.SlowMovement(moveSlow);
                        }
                    }
                }
            }
            if (playerIndex == 1)
            {
                if (attackHit.P2Hit())
                {
                    if (p1PlayerMove.IsHBlocking())
                    {
                        cooldown = stunTimer;
                    }
                    else
                    {
                        p1PlayerMove.GotHit(damage);
                        if (moveSlow > 0)
                        {
                            p1PlayerMove.SlowMovement(moveSlow);
                        }
                    }
                }
            }
        }
        LattackHitStarter -= Time.deltaTime;
        if (LattackHitStarter <= 0 && LattackHitCheck)
        {
            LattackHitStarter = 0;
            LattackHitCheck = false;
            if (playerIndex == 0)
            {
                if (attackHit.P1Hit())
                {
                    if (p2PlayerMove.IsLBlocking())
                    {
                        cooldown = stunTimer;
                    }
                    else
                    {
                        p2PlayerMove.GotHit(damage);
                        if (moveSlow > 0)
                        {
                            p1PlayerMove.SlowMovement(moveSlow);
                        }
                    }
                }
            }
            if (playerIndex == 1)
            {
                if (attackHit.P2Hit())
                {
                    if (p1PlayerMove.IsLBlocking())
                    {
                        cooldown = stunTimer;
                    }
                    else
                    {
                        p1PlayerMove.GotHit(damage);
                        if (moveSlow > 0)
                        {
                            p1PlayerMove.SlowMovement(moveSlow);
                        }
                    }
                }
            }
        }

        regenTime -= Time.deltaTime;
        if(regenTime <= 0f)
        {
            hp += regen;
            if(rb.velocity.x == 0)
            {
                hp += NoMoveRegen;
            }
            if (hp > hpMax) hp = hpMax;

            if(playerIndex == 0)
            {
                p1Slider.value = hp;
            }
            if (playerIndex == 1)
            {
                p2Slider.value = hp;
            }
            regenTime = 1f;
        }
    }
    public void AbilitiesChooser(int cardChoosen)
    {
        int ability = 0;
        if (cardChoosen == 1)
        {
            ability = randomEntry1.Value;
        }
        else if (cardChoosen == 2)
        {
            ability = randomEntry2.Value;
        }
        else if(cardChoosen == 3)
        {
            ability = randomEntry3.Value;
        }
        if (ability == 0)
            damage += .5f;
        if (ability == 1)
            hpMax += 2f;
        if (ability == 2)
            speed *= 1.5f;
        if (ability == 3)
            regen += 0.2f;
        if (ability == 4)
            NoMoveRegen += 0.4f;
        if (ability == 5)
            cooldownReduction += 0.1f;
        if (ability == 6)
        {
            if (playerIndex == 0)
            {
                p2PlayerMove.StunTime();
            }
            if (playerIndex == 1)
            {
                p1PlayerMove.StunTime();
            }
        }
        if (ability == 7)
            range += 0.15f;
        if (ability == 8)
            moveSlow += 1f;
        Debug.Log(ability);
        Start();
        if (playerIndex == 0)
            p2PlayerMove.Start();
        if (playerIndex == 1)
            p1PlayerMove.Start();
    }
}
