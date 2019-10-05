using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Controllers/GameSettings")]
public class ControllersSO : ScriptableObject
{
    [Header("Boundaries")]
    [SerializeField]
    private float _wallWidth = 1;

    [SerializeField]
    private string _wallsParentName = "Boundaries";

    [SerializeField]
    private string _leftWallName = "Left wall";

    [SerializeField]
    private string _rightWallName = "Right wall";

    [SerializeField]
    private string _topWallName = "Top wall";

    [SerializeField]
    private string _botWallName = "Bot wall";

    [Header("Threats")]
    [SerializeField]
    [Range(0.1f, 10)]
    private float _baseThreatSpeed = 1;

    public float WallWidth { get => _wallWidth; }
    public string WallsParentName { get => _wallsParentName; }
    public string LeftWallName { get => _leftWallName; }
    public string RightWallName { get => _rightWallName; }
    public string TopWallName { get => _topWallName; }
    public string BotWallName { get => _botWallName; }
    public float BaseThreatSpeed { get => _baseThreatSpeed; }
}
