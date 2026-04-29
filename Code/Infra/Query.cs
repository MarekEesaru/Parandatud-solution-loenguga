namespace Abc.Infra;

public sealed class Query(Dictionary<string, string> d = null)
{
    public static int[] PageSizes => [7, 15, 25, 50, 100];
    public int Page => toInt(get(nameof(Page)), 1);
    public int PageSize => toInt(get(nameof(PageSize)), PageSizes[0]);
    public string SortBy => get(nameof(SortBy));
    public string SortDir => get(nameof(SortDir));
    public string SearchBy => get(nameof(SearchBy));
    public string SearchStr => get(nameof(SearchStr));
    public string Selected => get(nameof(Selected));
    private string get(string name) => (d ?? []).TryGetValue(name, out var s) ? s : null;
    private static int toInt(string s, int def) => int.TryParse(s, out var i) ? i : def;
    private string sort => string.IsNullOrEmpty(SortBy)
        ? string.Empty : $"&SortBy={SortBy}&SortDir={SortDir}";
    private string search => string.IsNullOrEmpty(SearchStr)
        ? string.Empty : $"&SearchBy={SearchBy}&SearchStr={SearchStr}";
    public string Href(string baseUri, int? page = null, int? pageSize = null)
        => $"{baseUri}?Page={page ?? Page}&PageSize={pageSize ?? PageSize}{sort}{search}";
    public string Href(string baseUri, Guid id) => Href(baseUri) + $"&Select={id}";
}
