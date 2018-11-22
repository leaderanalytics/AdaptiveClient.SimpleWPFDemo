﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AdaptiveClient.WPFDemo
{
    public class UsersWebAPIClient : IUsersService
    {
        public void SaveUser(User user)
        {
            // httpClient.PostAsync(...)
        }

        public User GetUserByID(int id)
        {
            // httpClient.GetStringAsync(...)
            return new User { ID = id, Name = "Bob (retrieved from web API)" };
        }

        #region IDisposable
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
