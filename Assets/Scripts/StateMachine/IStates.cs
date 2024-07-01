public interface IStates<T> where T : class
{
    public T Controller { get; set; }
    public void OnStateEnter();
    public void OnStateExit();
    public void Update();
}
