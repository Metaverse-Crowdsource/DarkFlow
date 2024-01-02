using Cinemachine;
using StarterAssets;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;


    public class ClientPlayerSetings : NetworkBehaviour
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
            Invoke("Initialize", .5f);
        }

        void Initialize()
        //void Update()
        {
            //Debug.Log(".......... ClientPlayerSeting 1");
            if (!IsOwner) { return; }
            // player input is only enabled on owning players
            m_PlayerInput.enabled = true;
            m_ThirdPersonController.enabled = true;
            m_CharacterController.enabled = true;
            GetComponent<ThirdPersonController>()._mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            FindObjectOfType<CinemachineVirtualCamera>().Follow = m_CameraFollow;
            //if (IsSpawned) { return; }
            //Debug.Log(".......... ClientPlayerSeting 2");

        }

    }

