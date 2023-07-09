using UnityEngine;

public class Road : Scrollable
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public float SpriteVerticalSize => spriteRenderer.size.y;

    private RoadGenerator _roadGenerator;
    
    public void SetUp(RoadGenerator roadGenerator)
    {
        _roadGenerator = roadGenerator;
    }
    
    protected override void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if (WillDestroy) _roadGenerator.SpawnRoadPrefab();
    }
}