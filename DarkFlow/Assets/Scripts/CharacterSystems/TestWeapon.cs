using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Netcode;

public class TestWeapon : NetworkBehaviour
{

    public GameObject bulletObject;

 
    void Update()
    {

        //if (!isLocalPlayer) return;

        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            TestFire();
        }
    }


    void TestFire()
    {
        GameObject bullet = Instantiate(bulletObject, transform.position, transform.rotation);
 //       NetworkServer.Spawn(bullet, connectionToClient);
    }

}
