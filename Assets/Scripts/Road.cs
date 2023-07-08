using UnityEngine;

public class Road : Scrollable
{
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