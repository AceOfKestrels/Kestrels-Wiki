namespace Kestrels_Wiki.Services;
public class RepoService
{
    public string Content { get; private set; }

    public async void FetchContent()
    {
        HttpClient client = new();
        client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.raw+json");
        client.DefaultRequestHeaders.Add("User-Agent", "AceOfKestrels");
        var response = await client.GetAsync("https://api.github.com/repos/AceOfKestrels/Brain/git/blobs/310386b456c2400bfd85716d153c9a3a6e34fc5d");

        using StreamReader reader = new(response.Content.ReadAsStream());
        Content = reader.ReadToEnd().Replace("<", "&lt;");

        using StreamWriter writer = new(File.OpenWrite("./wwwroot/test.md"));
        writer.Write(Content);
    }

}
