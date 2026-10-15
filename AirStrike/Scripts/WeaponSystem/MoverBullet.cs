using UnityEngine;
using System.Collections;

public class MoverBullet : WeaponBase
{
    public int Lifetime;
    public float Speed = 80;
    public float SpeedMax = 80;
    public float SpeedMult = 1;

    private void Start()
    {
        Destroy(gameObject, Lifetime);
    }
	// move bullet by force
    private void FixedUpdate()
    {
		if(!this.GetComponent<Rigidbody>())
			return;
		
        if (!RigidbodyProjectile)
        {
            GetComponent<Rigidbody>().linearVelocity = transform.forward*Speed;
        }else{
			if(this.GetComponent<Rigidbody>().linearVelocity.normalized!=Vector3.zero)
			this.transform.forward = this.GetComponent<Rigidbody>().linearVelocity.normalized;	
		}
        if (Speed < SpeedMax)
        {
            Speed += SpeedMult * Time.fixedDeltaTime;
        }
    }

}
