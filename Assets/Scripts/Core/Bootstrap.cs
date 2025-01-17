using RopeGame.Audio;
using RopeGame.Puzzle.Data;
using RopeGame.Puzzle.Ropes;
using RopeGame.Puzzle.Ropes.Interfaces;
using RopeGame.Puzzle.Solution;
using RopeGame.Puzzle.Solution.Interfaces;
using RopeGame.Puzzle.Spawn;
using RopeGame.SceneLoading;
using RopeGame.Score;
using RopeGame.Score.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

namespace RopeGame.Core
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private PuzzleNodesRopes puzzleNodesRopes;
        [SerializeField] private PuzzleSpawner _puzzleSpawner;
        [SerializeField] private SkipButton _skipButton;
        [SerializeField] private ScoreUI _scoreUI;
        [SerializeField] private AudioPlayer _audioPlayer;
        [SerializeField] private ParticleSystem _congratsParticles;
        [SerializeField] private GameObject _congratsUI;

        private ISceneLoader _sceneLoader;
        private IPuzzleSolvedEvents _puzzleSolvedEvents;
        private IScoreTracker _scoreTracker;
        private IRopeIntersectionChecker _ropeIntersectionChecker;
        private IRopeMover _ropeMover;
        private IPuzzleSkipper _puzzleSkipper;

        [Inject]
        private void Construct(ISceneLoader sceneLoader, IPuzzleSolvedEvents puzzleSolvedEvents, IScoreTracker scoreTracker,
            IRopeIntersectionChecker ropeIntersectionChecker, IRopeMover ropeMover, IPuzzleSkipper puzzleSkipper)
        {
            _sceneLoader = sceneLoader;
            _puzzleSolvedEvents = puzzleSolvedEvents;
            _scoreTracker = scoreTracker;
            _ropeIntersectionChecker = ropeIntersectionChecker;
            _ropeMover = ropeMover;
            _puzzleSkipper = puzzleSkipper;
        }
        
        private void Awake()
        {
            _puzzleSpawner.SpawnPuzzle(puzzleNodesRopes);
            
            InitializeNodes();

            _puzzleSkipper.SetNodes(_puzzleSpawner.SpawnedNodes, puzzleNodesRopes.NodesSettings);
            
            _ropeMover.SetRopes(_puzzleSpawner.SpawnedRopes);
            _ropeIntersectionChecker.SetRopes(_puzzleSpawner.SpawnedRopes);
            
            _skipButton.Initialize(_puzzleSkipper);

            _scoreUI.Initialize(_scoreTracker);
        
            InitializePuzzleSolution();

            _ropeMover.MoveRopes();
            _ropeIntersectionChecker.CheckIntersections();
        }

        private void InitializeNodes()
        {
            foreach (var node in _puzzleSpawner.SpawnedNodes)
            {
                node.Initialize(_ropeMover, _ropeIntersectionChecker);

                _puzzleSolvedEvents.OnPuzzleSolved += node.Disable;
                _puzzleSolvedEvents.OnPuzzleSkipped += node.Disable;

                node.OnStartDrag += () => _audioPlayer.PlaySingleSound(puzzleNodesRopes.NodeClickSound);
                node.OnDrag += () => _audioPlayer.PlayContinuousSound(puzzleNodesRopes.RopeDragSound);
                node.OnEndDrag += () => _audioPlayer.StopContinuousSound();
            }
        }

        private void InitializePuzzleSolution()
        {
            _puzzleSolvedEvents.OnPuzzleSolved += () =>
            {
                _scoreTracker.UpdateScore(350);
                _congratsParticles.Play();
                _skipButton.gameObject.SetActive(false);
                _congratsUI.SetActive(true);
                StartCoroutine(_sceneLoader.LoadSceneAfterDelay("Map", 3));
            };

            _puzzleSolvedEvents.OnPuzzleSkipped += () =>
            {                
                _skipButton.gameObject.SetActive(false);
                StartCoroutine(_sceneLoader.LoadSceneAfterDelay("Map", 3));
            };
        }
    }
}