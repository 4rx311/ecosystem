namespace Assets.Scripts.Creatures.States
{
    public class Empty : IState
    {
        private static readonly IState _instance = new Empty();
        public static IState Instance => _instance;
        
        public void OnTick()
        {
        }

        public void OnEnter()
        {
        }

        public void OnExit()
        {
        }
    }
}