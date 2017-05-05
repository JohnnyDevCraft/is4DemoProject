using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityTest.IdentityApi
{
    public static class Config
    {

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>{
                new ApiResource("api1", "My Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>{
                new Client{
                    ClientId = "client",

                    // no interactive user, use the clientid/secret for authentication
		            AllowedGrantTypes = GrantTypes.ClientCredentials,

		            // secret for authentication
		            ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

		            // scopes that client has access to
		            AllowedScopes = { "api1" }
                },
                new Client{
                    ClientId = "ro.client",

                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },

                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                }

            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser>{
                new TestUser(){
                    SubjectId = "1",
                    Username = "john",
                    Password = "Snafu201"
                },
                new TestUser(){
                    SubjectId = "2",
                    Username = "Mike",
                    Password = "Secrete1"
                }
            };
        }


    }
}