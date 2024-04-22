namespace GithubWEBAppLean.Model;

public class User
{
    public int id { get; set; }
    public string login { get; set; } = string.Empty;
    public string node_id { get; set; } = string.Empty;
    public string avatar_url { get; set; } = string.Empty;
    public string gravatar_id { get; set; } = string.Empty;
    public string url { get; set; } = string.Empty;
    public string html_url { get; set; } = string.Empty;
    public string followers_url { get; set; } = string.Empty;
    public string gists_url { get; set; } = string.Empty;
    public string starred_url { get; set; } = string.Empty;
    public string subscriptions_url { get; set; } = string.Empty;
    public string organizations_url { get; set; } = string.Empty;
    public string repos_url { get; set; } = string.Empty;
    public string events_url { get; set; } = string.Empty;
    public string received_events_url { get; set; } = string.Empty;
    public string type { get; set; } = string.Empty;
    public bool site_admin { get; set; } 
    public string name { get; set; } = string.Empty;
    public string company { get; set; } = string.Empty;
    public string blog { get; set; } = string.Empty;
    public string location { get; set; } = string.Empty;
    public object email { get; set; }
    public object hireable { get; set; } 
    public object bio { get; set; }
    public string twitter_username { get; set; } = string.Empty;
    public int public_repos { get; set; } 
    public int public_gists { get; set; } 
    public int followers { get; set; } 
    public int following { get; set; } 
    public DateTime created_at { get; set; } 
    public DateTime updated_at { get; set; } 
}
