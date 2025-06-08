using UnityEngine;

public class Puzzle : MonoBehaviour
{


    protected void NotifyPuzzelResolved()
    {
        PuzzlesController.Instance.PuzzlesResolved();
    }
}
