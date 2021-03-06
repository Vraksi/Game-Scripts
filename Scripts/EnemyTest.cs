﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    public int hp;
    public float speed;
    public float dazedTime;
    public float startDazedTime;
    public GameObject bloodEffect;

    //void Start()
    //{
    //    anim = GetComponent<Animator>();
    //    anim.SetBool("isRunning", true);
    //}

    void Update()
    {
        if(dazedTime <= 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDmg(int dmg)
    {
        dazedTime = startDazedTime;
        hp -= dmg;
        Debug.Log("Damage taken " + dmg);
    }
}
