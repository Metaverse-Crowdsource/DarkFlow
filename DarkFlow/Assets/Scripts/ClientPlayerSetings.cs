using System;
using Cinemachine;
using StarterAssets;
using Unity.Jobs;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

/// Assumes client authority
//[DefaultExecutionOrder(1)] // after server component
public class ClientPlayerSetings : NetworkBehaviour
//public class ClientPlayerSetings : MonoBehaviour
{

    [SerializeField]
    CharacterController m_CharacterController;

    [SerializeField]
    ThirdPersonController m_ThirdPersonController;


    [SerializeField]
    Transform m_CameraFollow;

    [SerializeField]
    PlayerInput m_PlayerInput;



    public override void OnNetworkSpawn()
    {

        m_ThirdPersonController.enabled = false;

        Invoke("Initialize", .5f);

    }

    void Initialize()
    {
        Debug.Log(".......... ClientPlayerSeting 1");
        if (!IsOwner) { return; }

        // player input is only enabled on owning players
        m_PlayerInput.enabled = true;
        m_ThirdPersonController.enabled = true;
        m_CharacterController.enabled = true;

        GetComponent<ThirdPersonController>()._mainCamera = GameObject.FindGameObjectWithTag("MainCamera");

        //var cinemachineVirtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        //cinemachineVirtualCamera.Follow = m_CameraFollow;
        FindObjectOfType<CinemachineVirtualCamera>().Follow = m_CameraFollow;
        Debug.Log(".......... ClientPlayerSeting 2");
    }




}
