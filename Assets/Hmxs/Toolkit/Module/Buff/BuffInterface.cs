namespace Hmxs.Toolkit.Module.Buff
{
    public interface IBuffBaseEvent
    {
        public void OnAttach(BuffInfo buffInfo);
        public void OnRemove(BuffInfo buffInfo);
    }

    public interface IBuffTickEvent
    {
        public void OnTick(BuffInfo buffInfo);
    }

    public interface IBuffHitEvent
    {
        public void OnHit(BuffInfo buffInfo);
        public void OnKill(BuffInfo buffInfo);
        public void OnInjured(BuffInfo buffInfo);
        public void OnDie(BuffInfo buffInfo);
    }
}