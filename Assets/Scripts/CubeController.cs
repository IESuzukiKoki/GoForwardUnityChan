using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    /// <summary>
    /// 音声再生フラグ
    /// true=再生済み false=未再生  
    /// </summary>
    private bool isSEPlay;

    /// <summary>
    /// 音声再生
    /// </summary>
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        isSEPlay = false;
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            audioSource.PlayOneShot(audioClip);
        }

        if (collision.gameObject.CompareTag("Cube"))
        {
            CubeController cubeController = collision.gameObject.GetComponent<CubeController>();

            if (!this.isSEPlay || !cubeController.isSEPlay)
            {
                if (this.transform.position.y < collision.transform.position.y)
                {
                    this.isSEPlay = true;
                }
                else
                {
                    cubeController.isSEPlay = true;
                }

                audioSource.PlayOneShot(audioClip);
                Debug.Log("kitayo");
            }



        }
    }
}
