namespace Assets.Scripts.Creatures.States
{
    public interface IState
    {
        void DoOnTick();
        void OnEnter();
        void OnExit();
    }
}