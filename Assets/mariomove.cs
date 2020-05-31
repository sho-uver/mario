using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mariomove : MonoBehaviour {
    Rigidbody2D rigid2D;
    float jumpForce = 1550.0f;
    float walkForce = 60.0f;
    float maxWalkSpeed = 9.0f;
    private string enemyTag = "enemy";
    private CapsuleCollider2D capcol = null;
    bool isJump = false;
    bool isOtherJump = false;
    bool isDown = false;

    // Start is called before the first frame update
    void Start () {
        this.rigid2D = GetComponent<Rigidbody2D> ();
        capcol = GetComponent<CapsuleCollider2D> ();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown (KeyCode.Space) &&
            this.rigid2D.velocity.y == 0) {
            this.rigid2D.AddForce (transform.up * this.jumpForce);
        }
        int key = 0;
        if (Input.GetKey (KeyCode.RightArrow)) key = 1;
        if (Input.GetKey (KeyCode.LeftArrow)) key = -1;
        float speedx = Mathf.Abs (this.rigid2D.velocity.x);
        if (speedx < this.maxWalkSpeed) {
            this.rigid2D.AddForce (transform.right * key * this.walkForce);
        }
        if (key != 0) {
            transform.localScale = new Vector3 (key, 1, 1);
        }
        if (transform.position.y < -20) {
            SceneManager.LoadScene ("GameOver");
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
        Debug.Log ("ゴール");
        SceneManager.LoadScene ("clear");
    }

    //接触判定
    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.collider.tag == enemyTag) {
            Debug.Log ("敵と接触した！");
            isDown = true;
        }
        float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));
        float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;
        foreach (ContactPoint2D p collision.contacts) {
            if (p.point.y < judgePos) {
                private bool isOtherJump = false;
                private float other JumpHeight = 0.0f;
            }
        }
    }

    //ジャンプしてるかどうか
    private float GetYSpeed () {
        float verticalkey = Input.GetAxis ("Vertical");
        float ySpeed = -gravity;
        if (isGround) {
            if (verticalKey > 0 && jumpTime < jumpLimitTime) {
                ySpeed = jumpSpeed;
                jumpPos = trnsform.position.y;
                isJump = true;
                jumpTime = 0.0f;
            } else {
                isJump = false;
            }
        } else if (isJump) {
            if (verticalKey > 0 && jumpPos + jumpHeight > transform.position.y && jumpTime < jumpLimitTime && !isHead) {
                ySpeed = jumpSpeed;
                jumpTime += Time.deltaTime;
            } else {
                isJump = false;
                jumpTime = 0.0f;
            }
        }
        if (isJump) {
            ySpeed *= jumpCurve.Evaluate (jumpTime);
        } else if (isOtherJump) {
            if (jumpPos + otherJumpHeight > transform.position.y && jumpTime < ) {
                ySpeed = jumpSpeed;
                jump += Time.delataTime;
            } else {
                isOtherJump = false;
                jumpTime = 0.0f;
            }
        }
        return ySpeed;
    }

    private bool isOtherJump = false;
    private float otherJumpHeight = 0.0f;

    if (isJump || isOtherJump) {
        ySpeed *= jumpCurve.Evaluate (jumpTime);
    }

    private void OnCollisionEnetr2D (Collison2D collision) {
        if (collision.collider.tag == enemyTag) {
            float stepOnHeight = (capcol.size.y * (stemOnRate / 100f));
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;
            foreach (ContactPoint2D p in collision.contacts) {
                if (p.point.y < judgePos) { } else { }
            }
        }
        ObjectCollision o = collision.gameObject.GetComponent < ObjectCollision ();
        if (o != null) {
            otherJumpHeight = o.boundHeight;
            o.playerStepOn = true;
            isOtherJump = true;
            isJump = false;
            jumpTime = 0.0f;
        } else {
            Debug.Log ("ObjrctCollisionがついてないよ！")
        }
    }

}