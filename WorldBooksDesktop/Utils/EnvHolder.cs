using System;
using DotNetEnv;

namespace WorldBooksDesktop.Utils
{
    internal class EnvHolder
    {
        private static readonly Lazy<EnvHolder> lazyInstance = new Lazy<EnvHolder>(() => new EnvHolder());

        public static EnvHolder Instance => lazyInstance.Value;

        public string Host { get; private set; }
        public string Database { get; private set; }
        public string User { get; private set; }
        public string Password { get; private set; }

        public string ConnectionString => $"Server={Host};Database={Database};User Id={User};Password={Password};";

        private EnvHolder()
        {
            Env.Load();

            Host = Environment.GetEnvironmentVariable("DB_HOST");
            Database = Environment.GetEnvironmentVariable("DB_DATABASE");
            User = Environment.GetEnvironmentVariable("DB_USERNAME");
            Password = Environment.GetEnvironmentVariable("DB_PASSWORD");
        }
    }
}
