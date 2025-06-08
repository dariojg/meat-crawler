using UnityEngine;

public class PuzzlesController : MonoBehaviour
{
    private static PuzzlesController instance;
    public static PuzzlesController Instance => instance;

    [SerializeField]int totalPuzzles = 0;

    [SerializeField] Puzzle[] puzzles;
    [SerializeField] Porton door;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

 

    void OpenDoor()
    {
        door.Open();
    }

    public void PuzzlesResolved()
    {
        totalPuzzles++;
        if(totalPuzzles >= puzzles.Length)
        {
            OpenDoor();
            Debug.Log("Todos los puzzles resueltos. Puerta abierta.");
        }
        else
        {
            Debug.Log($"Puzzles restantes: {puzzles.Length}");
        }
    }


}
