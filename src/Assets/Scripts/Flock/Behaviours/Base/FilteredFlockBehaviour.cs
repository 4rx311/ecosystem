using Behaviours.FlockBehaviours;

namespace Assets.Scripts.Creatures.Components.FlockContextFilters
{
    public abstract class FilteredFlockBehaviour : FlockBehaviour
    {
        public ContextFilter filter;
    }
}