using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    public Sender sender;
    public float radius = 5;
    public float explosionforce = 1000;
    public GameObject explosionPrefab;

    void Awake()
    {
        Destroy(gameObject, 5f);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(gameObject,1f);
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject,1f);
        healthInfo healthinfo = collision.gameObject.GetComponent<healthInfo>();

        //bunu engellemek için etiketleme oluşturuldu
        //atılan bomba kendine aitse o zaman gönderen hasar almamalı
        //bombaya ait olan sender bombayı atana ait değilse hasar alınsın
        if(healthinfo != null && sender != collision.gameObject.GetComponent<Tank>().sender)
        {
            healthinfo.TakeDamage(10);
        }


        CreateExplosionEffect();

    }

    //efekt
    private void CreateExplosionEffect()
    {

        var explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        //overlapsphere bize çarptığı alandaki objeleri bir dizi halinde döndürür
        Collider[] nearbyObject = Physics.OverlapSphere(transform.position, radius);

        foreach (var nearby in nearbyObject)
        {
            Rigidbody rb = nearby.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionforce, transform.position, radius);
            }
        }
        //efekt 1sn sonra yok edilsin.
        Destroy(explosion,1f);
    }
}
