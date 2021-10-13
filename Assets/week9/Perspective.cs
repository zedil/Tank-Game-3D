using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : Sense
{
    float fieldofView;
    float maxCheckDistance;
    //Animator fsm {get {return GetComponent<Animator>(); }}

    public override void InitializeSense()
    {
        //görme açısı 60 derece
        fieldofView = 60;

        //belli bir uzaklığın üstündeyken zaten kontrol etmemeli
        maxCheckDistance = 15;
    }

    public override void UpdateSense()
    {
        //perspektif enemy içinde o yüzden direkt transform.position alabiliriz.
        Vector3 forward = transform.forward;

        //enemy ile player arasındaki fark
        Vector3 dir = (player.position - transform.position).normalized;

        //aradaki açıya bakıyoruz
        float angle = Vector3.Angle(dir, forward);


        //eğer bu angle tanımladığımız görüş alanının içerisindeyse bu ife girecek
        if( angle<(fieldofView/2f))
        {
            //ışın göndermeliyiz çünkü görüş alanı içerisinde
            Ray ray = new Ray(transform.position, dir);

            //ışın çizme
            //Debul.DrawRay(transform.origin, dir*maxCheckDistance, Color.red);

            //ışın objeye çarpıyorsa, ışın objeyi kesiyorsa
            if (Physics.Raycast(ray, out RaycastHit info, maxCheckDistance))
            {

                //ışının çarptığı obje playerTank mı bakalım
                var player = info.transform.GetComponent<playerTank>();
                if(player != null)
                {
                    fsm.SetBool("isVisible", true);
                }
                else
                {
                    fsm.SetBool("isVisible", false);
                }
            }
        }
        else
        {
            fsm.SetBool("isVisible", false);
        }
    }
}
