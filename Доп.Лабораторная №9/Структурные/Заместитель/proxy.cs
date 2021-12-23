using System;

namespace ConsoleApp8
{
    class Client
    {
        private string id;
        public string Id { get => id; }
        public Client(string id = "#1")
        {
            this.id = id;
        }
    }
    interface IServer
    {
        void AccessGranted(Client user);
        void AccessClosed(Client user);
    }
    class Server : IServer
    {
        public Server() => Console.WriteLine("Сервер создан");
        public void AccessClosed(Client user) => Console.WriteLine($"Доступ закрыт пользователю с ID {user.Id}");
        public void AccessGranted(Client user) => Console.WriteLine($"Доступ предоставлен пользователю с ID {user.Id}");
    }
    class ServerCheck : IServer
    {
        private Lazy<Server> server;
        public ServerCheck() { }

        public void AccessGranted(Client client)
        {
            if (server == null) Console.WriteLine($"Неизвестный пользователь");
            else server.Value.AccessGranted(user: client);
        }
        public void Authentication(Client client)
        {
            if (client.Id != "#1") return;
            Console.WriteLine($"Пользователь известен");
            server = new();
            AccessGranted(client);

        }
        public void AccessClosed(Client client)
        {
            if (server == null) { Console.WriteLine("Аутентификация не пройдена"); return; }
            server.Value.AccessClosed(user: client);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new();

            ServerCheck proxy = new();
            proxy.AccessGranted(client: client);
            proxy.AccessClosed(client: client);

            Console.WriteLine("\n\nАутентификация");
            proxy.Authentication(client);

            Console.WriteLine("\n\nДоступ");
            proxy.AccessGranted(client: client);

            Console.WriteLine("\n\nЗакрытие доступа");
            proxy.AccessClosed(client: client);
        }
    }
}
