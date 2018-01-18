public class State
{
    public enum Height
    {
        High,
        Middle,
        Low
    };
    public enum Input
    {
        Attack,
        Neutral,
        Defend,
        Special
    };
    Height height;
    Input input;

    public State(Height h, Input i)
    {
        height = h;
        input = i;
    }

    public Height getHeight()
    {
        return height;
    }

    public Input getInput()
    {
        return input;
    }
    
}