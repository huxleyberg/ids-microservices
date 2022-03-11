using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthServer.Config
{
    public class MemoryConfig
    {
        //this has to do with the identity of the user
        public static IEnumerable<IdentityResource> IdentityResources() =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<Client> Clients() =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "first-client",
                    ClientSecrets = new []{new Secret("chidiSecret".ToSha512())},
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    AllowedScopes = {IdentityServerConstants.StandardScopes.OpenId}

                }
            };

        public static List<TestUser> TestUsers() =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "abcd1234",
                    Username = "chidi",
                    Password = "chidisPassword",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name","chidi"),
                        new Claim("family_name", "xyz")
                    }
                },
                new TestUser
                {
                    SubjectId = "abc2",
                    Username = "Kiol",
                    Password = "fghjk",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name","jpo"),
                        new Claim("family_name", "yui")
                    }
                }
            };
    }
}
