
using UnityEngine;

public class BlockSelectableManager : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField] private Buildings buildings;
    [SerializeField] private Transform parent;

    void Start()
    {
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider )
            {
                BlockForBuildings blockForBuildings = hit.collider.gameObject.GetComponent<BlockForBuildings>();
                if(blockForBuildings)
                    blockForBuildings.SetBuilding(buildings, parent);
            }
        }
    }
}
