namespace ToyRobot.App
{
    public struct Action
    {
        public string Type;
        public string Args;

        public Action(string type, string args)
        {
            Type = type;
            Args = args;
        }
    }
}
