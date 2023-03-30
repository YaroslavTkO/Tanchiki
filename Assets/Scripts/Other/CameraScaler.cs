using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    private Renderer mapSize;
    readonly private float additionalScale = 1.3f;
    private GameObject[] tanks;
    private Camera _camera;

    private float maxWidth, maxHeight, minWidth, minHeight;
    private int pixelWidth, pixelHeight;
    private float aspect, posZ;

    private void Start()
    {
        _camera = Camera.main;
        pixelHeight = _camera.pixelHeight;
        pixelWidth = _camera.pixelWidth;
        aspect = _camera.aspect;
        posZ = _camera.transform.position.z;

        mapSize = GetComponent<Renderer>();
        maxWidth = mapSize.bounds.size.x;
        maxHeight = mapSize.bounds.size.y;
        minWidth = maxWidth / 1.5f;
        minHeight = maxHeight / 1.5f;


    }
    private bool GetTanks()
    {
        if (tanks != null && tanks.Length == 2)
        {
            if (tanks[0] == null || tanks[1] == null)
            {
                tanks = null;
                return false;
            }

            return true;
        }

        tanks = GameObject.FindGameObjectsWithTag("Player");
        if (tanks.Length == 2)
            return true;
        return false;
    }

    private void Update()
    {
        if (GetTanks())
            ChangeCameraToFitTanks();
    }
    private void ChangeCameraToFitTanks()
    {
        if (tanks.Length == 2)
        {
            var x1 = tanks[0].transform.position.x;
            var x2 = tanks[1].transform.position.x;
            var y1 = tanks[0].transform.position.y;
            var y2 = tanks[1].transform.position.y;

            var width = Mathf.Abs(x1 - x2) * 2;
            var height = Mathf.Abs(y1 - y2);
            width = GetMedium(width, minWidth, maxWidth);
            height = GetMedium(height, minHeight, maxHeight);

            var pos = new Vector3((x1 + x2) / 2, (y1 + y2) / 2, posZ);

            _camera.orthographicSize = ((width > height * aspect) ?
            width / pixelWidth * pixelHeight : height) / 2 * additionalScale;

            _camera.gameObject.transform.position = pos;
        }
    }

    private float GetMedium(float numb, float min, float max)
    {
        if (numb > max)
            numb = max;
        else if (numb < min)
            numb = min;

        return numb;
    }
}
