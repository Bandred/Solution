namespace CrossCutting.Swagger
{
    public interface ISwaggerData
    {
        string Title { get; }
        string Version { get; }
        string Xml { get; }
    }
}
