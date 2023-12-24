using Cinemachine;
using UnityEngine;
//using UnityEngine.Assertions;

public class CameraController : MonoBehaviour
{

    //private CinemachineVirtualCamera m_MainCamera;
    private Transform m_CharFollow;
    public CinemachineVirtualCamera m_CamFollow;

    void Start()
    {
        AttachCamera();
    }

    private void AttachCamera()
    {
        //m_MainCamera = GameObject.FindObjectOfType<CinemachineVirtualCamera>();
        //Assert.IsNotNull(m_MainCamera, "Couldn't find gameplay camera");

        m_CharFollow = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).transform;

        //if (m_MainCamera)
        if (m_CamFollow)
        {
            //m_MainCamera.Follow = m_CharFollow;
            m_CamFollow.Follow = m_CharFollow;
            //m_MainCamera.LookAt = m_CharFollow;
            m_CamFollow.LookAt = m_CharFollow;

            // camera body / aim
            //m_MainCamera.Follow = transform;
            //m_MainCamera.LookAt = transform;
            // default rotation / zoom
            // m_MainCamera.m_Heading.m_Bias = 40f;
            //m_MainCamera.m_YAxis.Value = 0.5f;

        }
    }
}

