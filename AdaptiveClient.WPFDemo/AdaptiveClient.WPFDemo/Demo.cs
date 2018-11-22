using System;
using System.Collections.Generic;
using System.Text;
using LeaderAnalytics.AdaptiveClient;

namespace AdaptiveClient.WPFDemo
{
    // In a real application this Demo class would most likely be a Controller or a ViewModel.
    // Here we inject a single service, UsersService, as is shown in the constructor below.
    // However we can also inject a facade or manifest that will give us easy access to hundreds of services.
    // 
    public class Demo
    {
        private IAdaptiveClient<IUsersService> adaptiveClient;
        private API_Result apiResult;

        public Demo(IAdaptiveClient<IUsersService> adaptiveClient)
        {
            this.adaptiveClient = adaptiveClient;
            this.apiResult = new API_Result();
        }

        public API_Result Simulate_API_Calls()
        {
            // Make some calls to UsersService which we have mocked up to simulate a service that reads/writes to a database.
            // Three calls are made to this method:  
            // First call we show we can make calls to a service that reads/writes a MSSQL database.
            // Second call we show we can make calls to a service that reads/writes a MySQL database.
            // Third call we simulate a failure and we fall back to a mocked WebAPI client.

            int id = 1;
            User user = GetUser(id);
            SaveUser(user);
            return apiResult;
        }

        private User GetUser(int id)
        {
            // An error here is expected on the web api call as we are simulating an error connecting to a server.  Click "Continue" in Visual Studio IDE.
            User user = adaptiveClient.Try(x => x.GetUserByID(id));
            apiResult.GetUserResult = $"User {user.Name} was found.  EndPoint used was {adaptiveClient.CurrentEndPoint.Name}.";
            return user;
        }

        private void SaveUser(User user)
        {
            adaptiveClient.Try(x => x.SaveUser(user));
            apiResult.SaveUserResult = $"User {user.Name} was saved.  EndPoint used was {adaptiveClient.CurrentEndPoint.Name}.";
        }
    }
}
