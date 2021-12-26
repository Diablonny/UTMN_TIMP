using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp9
{
    interface IChat
    {
        void SendMessage(string message, User user);
        void AppendUser(User user);
    }
    class Mediator : IChat
    {
        private List<User> users;
        public Mediator() => users = new List<User>();
        public void AppendUser(User user) => users.Add(user);

        //Пробежаться по всем юзерам, кроме отправителя и отправить им сообщение
        public void SendMessage(string message, User me)
        {
            users.Where(user => user != me).ToList().ForEach(e => e.PrintMessage(message));
            Console.WriteLine("====");
        }
    }
    class User
    {
        private IChat chatroom; //юзер знает о существовании конкретного чата
        private string nickname;
        public string Nickname => nickname;
        public User(IChat chat, string nick)
        {
            this.chatroom = chat;
            this.nickname = nick;
        }

        //отправить сообщение в чат
        public void SendMessage(string text) { chatroom.SendMessage(text, this); }
        public void PrintMessage(string text) { Console.WriteLine($"{nickname}: {text}"); }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mediator tumgychat = new Mediator();

            var sergey = new User(tumgychat, "Сергей");
            var michail = new User(tumgychat, "Миша");
            var jenya = new User(tumgychat, "Женя133");

            tumgychat.AppendUser(sergey);
            sergey.SendMessage("Привет, скиньте паттерн посредник по тимпу");
            sergey.SendMessage("А где все");

            tumgychat.AppendUser(michail);
            michail.SendMessage("Привет, я Миша");

            sergey.SendMessage("Есть паттерн посредник?");
            michail.SendMessage("Неа");

            tumgychat.AppendUser(jenya);
            jenya.SendMessage("Привет, я Женя");

            sergey.SendMessage("Есть паттерн посредник?");
            michail.SendMessage("Да");
        }
    }
}
