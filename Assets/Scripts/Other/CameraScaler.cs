using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    private Renderer objectToFitInCamera;
    readonly private float additionalScale = 1.3f;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        objectToFitInCamera = GetComponent<Renderer>();
        ChangeCameraSize();
    }

    private void ChangeCameraSize()
    {
        var size = objectToFitInCamera.bounds.size;
        var width = size.x;
        var height = size.y;

        _camera.orthographicSize = ((width > height * _camera.aspect) ?
            width / (float)_camera.pixelWidth * _camera.pixelHeight : height) / 2 * additionalScale;
    }
}
