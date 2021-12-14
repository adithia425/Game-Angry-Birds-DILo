using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBird : Burung
{
    [SerializeField]
    public float _boostForce = 100;

    //Cek Sudah Digunakan Atau Belum
    public bool _hasBoost = false;

    public void Boost()
    {
        if (State == BirdState.Thrown && !_hasBoost)
        {
            RigidBody.AddForce(RigidBody.velocity * _boostForce);
            _hasBoost = true;
        }
    }

    public override void OnTap()
    {
        Boost();
    }


}
