using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    public GameObject Score;
    private Rigidbody2D rb2D;
    private float jumpForce = 10.0f;
    public GameObject GameOverGUI;
    private bool gameover = false;
    private Animator anim;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent("Animator") as Animator;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameover)
        {
            Jump();
        }
        if (gameover == true)
        {
            //アニメーションの切替
            anim.SetBool("gameover", true);
            GameOverGUI.SendMessage("Lose");
        }
    }

    void Jump()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Score.SendMessage("ScoreUp", 1);
        Destroy(col.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        // ゲームオーバーのフラグをtrueにする
        gameover = true;
        // マウス連打してたらスコアを見る暇もなくタイトルへ戻ってしまう対策 1秒待機
        yield return new WaitForSeconds(1f);

        if (Input.GetMouseButtonDown(0)) { yield return 0; }
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
}
