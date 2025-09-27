using Duende.IdentityServer.Models;

namespace TodoList.Identity
{
    public static class Config
    {
        public static IEnumerable<Client> Clients =>
            [new Client
             {
                ClientId = "spa-client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "api1", "openid", "profile" },
                AllowOfflineAccess = true
            }];

        public static IEnumerable<ApiScope> ApiScopes =>
            [new ApiScope("api1", "TodoList API")];
        public static IEnumerable<ApiResource> ApiResources =>
            [new ApiResource("api1", "TodoList API") { Scopes = {"api1"}}];

        public static IEnumerable<IdentityResource> IdentityResources =>
            [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
            ];
    }
}
