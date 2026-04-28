namespace Abc.Shared.Code;

public sealed class Query(Dictionary<string, string> d = null)
{
    public int Page => toInt(get(nameof(Page)), 1);
    public int PageSize => toInt(get(nameof(PageSize)), 0);
    private string get(string name) => (d ?? []).TryGetValue(name, out var s) ? s : null;
    private static int toInt(string s, int def) => int.TryParse(s, out var i) ? i : def;
}
public class UrlParams(Uri url)
{
    private readonly Dictionary<string, string> d = [];
    public Query Parse()
    {
        var q = url?.Query?.TrimStart('?');
        if (string.IsNullOrEmpty(q)) return new Query();
        var pars = q.Split('&', StringSplitOptions.RemoveEmptyEntries);
        foreach (var p in pars) add(p.Split('=', 2));
        return new Query(d);
    }
    private void add(string[] pair)
    {
        if (pair.Length != 2) return;
        d[pair[0]] = Uri.UnescapeDataString(pair[1]);
    }
}
