using RopeGame.Puzzle.Ropes;
using RopeGame.Puzzle.Ropes.Interfaces;
using RopeGame.Puzzle.Solution;
using RopeGame.Puzzle.Solution.Interfaces;
using RopeGame.SceneLoading;
using RopeGame.Score;
using RopeGame.Score.Interfaces;
using VContainer;
using VContainer.Unity;

namespace RopeGame.Core
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IScoreTracker, ScoreTracker>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IRopeMover, RopeMover>(Lifetime.Singleton);
            builder.Register<IRopeIntersectionChecker, RopeIntersectionChecker>(Lifetime.Singleton);
            builder.Register<IPuzzleSkipper, PuzzleSkipper>(Lifetime.Singleton);
            builder.Register<IPuzzleSolvedEvents, PuzzleSolvedEvents>(Lifetime.Singleton);
        }
    }
}
