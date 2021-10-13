using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sender{ ENEMY, PLAYER}


public abstract class Tank : MonoBehaviour
{
    public Sender sender;
    public float moveSpeed;
    public float rotSpeed; //açısal olduğu için editör içinde açı değeri almalı 120 180 gibi

    public Transform other;
    public Transform turret;
    public Transform bombSpawn;
    public Rigidbody bombPrefab;
    public Rigidbody rb {get { return GetComponent<Rigidbody>(); }}

    //rigidbodyle yapılan işlemlerde fixedupdate kullanılır
    void FixedUpdate()
    {
        Move();
    }

    protected abstract void Move();

    protected IEnumerator TurnAndShoot()
    {
        //açının durumuyla ilgileniyoruz
        while (Vector3.Angle(turret.forward, (other.position - transform.position).normalized) >= 5 
        && Vector3.Distance(transform.position, other.position) > 5)
        //Vector3.Distance(transform.position, other.position) bunu yapmalıyız çünkü player enemyi aradığı için
        //sürekli turretı döndürüyor.
        {
            //turret'ın dönüşü
            //dönme eksenini dünya olarak verdik
            turret.Rotate(transform.up, Space.World);
            yield return null;
        }
        Fire();
    }

    protected void Fire()
    {
        var bomb = Instantiate(bombPrefab, bombSpawn.position, Quaternion.identity);

        //bombaya etiket atıldı
        bomb.GetComponent<bomb>().sender = this.sender;

        bomb.AddForce(turret.forward*5000);//turretın forwardına doğru
    }
}
