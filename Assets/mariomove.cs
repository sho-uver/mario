using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mariomove : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 680.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 4.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&
            this.rigid2D.velocity.y==0) { this.rigid2D.AddForce(transform.up * this.jumpForce); }
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        if (speedx < this.maxWalkSpeed) { this.rigid2D.AddForce(transform.right * key * this.walkForce); }
        if (key != 0) { transform.localScale = new Vector3(key, 1, 1); }
        if (transform.position.y < -20) { SceneManager.LoadScene("GameOver"); }
    }
        void OnTriggerEnter2D(Collider2D other) { Debug.Log("ゴール");
        SceneManager.LoadScene("clear");
       
    }
}
