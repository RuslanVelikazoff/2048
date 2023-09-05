using UnityEngine;

public class TileRow : MonoBehaviour
{
    public TileCell[] cells { get; private set; }

    private void Awake() //TODO: inicial
    {
        cells = GetComponentsInChildren<TileCell>();
    }
}
