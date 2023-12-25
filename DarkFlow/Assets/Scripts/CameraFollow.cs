using Unity.Netcode;
using Cinemachine;
using UnityEngine;
//using UnityEngine.Assertions;

public class CameraFollow : NetworkBehaviour
{

    private Transform m_CharFollow;
    public CinemachineVirtualCamera m_CamFollow;

    void Start()
    {

        if (!IsOwner) { return; }
        AttachCamera();

    }

    private void AttachCamera()
    {

        m_CharFollow = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform;

        if (m_CamFollow)
        {
            m_CamFollow.Follow = m_CharFollow;
            m_CamFollow.LookAt = m_CharFollow;

        }
    }
}

