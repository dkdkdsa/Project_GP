using Cinemachine;
using UnityEngine;

public class CameraManager : MonoSingleton<CameraManager>, ILocalInject
{

    private Camera _mainCam;
    private CinemachineVirtualCamera _cvcam;

    public void LocalInject(ComponentList list)
    {

        _mainCam = Camera.main;
        _cvcam = FindObjectOfType<CinemachineVirtualCamera>();

    }

    public void SetFollow(Transform target)
    {

        _cvcam.Follow = target;

    }

    public Camera GetCamera() => _mainCam;

}
