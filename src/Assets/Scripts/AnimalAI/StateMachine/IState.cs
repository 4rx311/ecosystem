namespace Assets.Scripts.Creatures.States
{
    public interface IState
    {
        void OnTick();
        void OnEnter();
        void OnExit();
    }
}