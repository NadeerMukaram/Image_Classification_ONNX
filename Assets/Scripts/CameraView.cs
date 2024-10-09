using UnityEngine;
using UnityEngine.UI;

public class CameraView : MonoBehaviour
{
    RawImage rawImage;
    AspectRatioFitter fitter;
    WebCamTexture webcamTexture;
    bool ratioSet;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        fitter = GetComponent <AspectRatioFitter>();
        InitWebCam();
    }

    void Update()
    {
        if (webcamTexture.width > 100 && !ratioSet)
        {
            ratioSet = true;
            SetAspectRatio();
        }
    }

    void SetAspectRatio()
    {
        fitter.aspectRatio = (float)webcamTexture.width / (float)webcamTexture.height;
    }

    void InitWebCam()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        string camName = "";

        // Try to find and use the front camera if available
        foreach (var device in devices)
        {
            if (device.isFrontFacing)
            {
                camName = device.name;
                break;
            }
        }

        // If no front camera is found, use the first available camera
        if (string.IsNullOrEmpty(camName) && devices.Length > 0)
        {
            camName = devices[0].name;
        }

        webcamTexture = new WebCamTexture(camName, Screen.width, Screen.height, 30);
        rawImage.texture = webcamTexture;
        webcamTexture.Play();
    }

    public WebCamTexture GetCamImage()
    {
        return webcamTexture;
    }
}
