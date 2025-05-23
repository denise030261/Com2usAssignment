using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    int speed; // Character move speed

    [SerializeField]
    float jumpPower; // Character jump speed

    [SerializeField]
    int MaxHp; // Character Hp

    [SerializeField]
    float noDamageSeconds; // UI HP Image

    [SerializeField]
    GameObject GameObjectHP; // UI HP Image

    [SerializeField]
    float damageForce; // UI HP Image

    [SerializeField]
    GameObject gameResultDisplay; 

    public int CurrentHp;

    GameObject[] ImageHP;
    Rigidbody2D rb2;
    Animator animator;
    float flipScale;

    bool isGound;
    bool isNoDamage;
    bool isMove;
    bool isLadder;

    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        Init();
        GameManager.Instance.Init();
    }

    private void Init()
    {
        gameResultDisplay.SetActive(false);
        flipScale = transform.localScale.x;
        isGound = false;
        isNoDamage = false;
        isMove = true;
        isLadder = false;
        CurrentHp = MaxHp;
    } // Initialization

    private void Update()
    {
        if(!isLadder)
            rb2.gravityScale = 1;

        if (Input.GetKey(KeyCode.LeftArrow) && isMove)
        {
            animator.SetBool("isMove", true);

            rb2.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
            rb2.velocity = new Vector2(Mathf.Max(rb2.velocity.x, -speed), rb2.velocity.y);
            transform.localScale = new Vector3(-flipScale, transform.localScale.y, transform.localScale.z);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && isMove) 
        {
            animator.SetBool("isMove", true);

            rb2.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
            rb2.velocity = new Vector2(Mathf.Min(rb2.velocity.x, speed), rb2.velocity.y);
            transform.localScale = new Vector3(flipScale, transform.localScale.y, transform.localScale.z);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) && isMove) 
        {
            animator.SetBool("isMove", false);
            rb2.velocity = new Vector3(rb2.velocity.normalized.x, rb2.velocity.y);
        } // Move

        if (Input.GetKeyDown(KeyCode.Space) && isGound && isMove && !isLadder)
        {
            rb2.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        } // Jump

        if(isLadder && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb2.gravityScale = 0;
            rb2.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
            rb2.velocity = new Vector2(rb2.velocity.x, Mathf.Min(rb2.velocity.y, speed));
        }
        else if(isLadder && Input.GetKeyDown(KeyCode.DownArrow))
        {
            rb2.gravityScale = 0;
            rb2.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
            rb2.velocity = new Vector2(rb2.velocity.x, Mathf.Min(rb2.velocity.y, speed));
        }

        if(CurrentHp<=0)
        {
            GameManager.Instance.isDie = true;
            gameResultDisplay.SetActive(true);
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag== "Ground")
        {
            isGound = true;
        }

        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("ÇÃ·§Æû¿¡ ÀÖÀ½");
            GameManager.Instance.isMissing = false;
        }

        if (collision.gameObject.tag == "Enemy" && !isNoDamage)
        {
            GetDamage();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGound = false;
        }
  
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("ÇÃ·§Æû¿¡ ¾øÀ½");
            GameManager.Instance.isMissing = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile"&&!isNoDamage)
        {
            GetDamage();
        }

        if(collision.gameObject.tag=="Ladder")
        {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ladder")
        {
            isLadder = false;
        }
    }

    void ChangeHP()
    {
        for (int i = 0; i < CurrentHp; i++)
        {
            GameObjectHP.transform.GetChild(i).gameObject.SetActive(true);
        }
        for(int i=CurrentHp;i<MaxHp;i++)
        {
            GameObjectHP.transform.GetChild(i).gameObject.SetActive(false);
        }
    } // Change UI HP Image

    void ChangeState()
    {
        Debug.Log("ÃÊ±âÈ­ ÇØÁ¦");
        isNoDamage = false;
        isMove = true;
        animator.SetBool("isHurt", false);
    } // Clear No Damage

    void GetDamage()
    {
        isNoDamage = true;
        isMove = false;
        CurrentHp--;
        ChangeHP();
        Invoke("ChangeState", noDamageSeconds);
        rb2.AddForce(new Vector2(-transform.localScale.x / Mathf.Abs(transform.localScale.x), 0) * damageForce, ForceMode2D.Impulse);
        animator.SetBool("isHurt", true);
    } // When Player gets damage
}
