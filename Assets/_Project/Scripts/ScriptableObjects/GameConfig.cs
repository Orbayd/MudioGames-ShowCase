using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig", order = 1)]
public class GameConfig : ScriptableObject
{

    [Header("Camera")]
    public Vector2 CameraOffset;

    [Header("Score")]

    public int ScoreGain;

    public int MaxScore;

}
