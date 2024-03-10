using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Grid grid;
    private int distFunEnumSize, pathAlgEnumSize;
    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("Director").GetComponent<Grid>();

        distFunEnumSize = System.Enum.GetNames(typeof(PathNode.DistanceFunction)).Length;
        pathAlgEnumSize = System.Enum.GetNames(typeof(Grid.PathAlgorithm)).Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            var distanceFunctionCode = (int)grid.CurrentDistanceFunction;
            grid.CurrentDistanceFunction = (PathNode.DistanceFunction)((distanceFunctionCode + 1) % distFunEnumSize);
            grid.ForceToUpdate();
        } else if (Input.GetKeyDown(KeyCode.P))
        {
            var pathAlgorithmCode = (int)grid.CurrentAlgorithm;
            grid.CurrentAlgorithm = (Grid.PathAlgorithm)((pathAlgorithmCode + 1) % pathAlgEnumSize);
            grid.ForceToUpdate();
        }else if (Input.GetKeyDown(KeyCode.F))
        {
            grid.ForceToUpdate();
        }
    }
}
