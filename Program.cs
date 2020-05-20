using System;
using System.Collections.Generic;
using CodeLouTodo.Models;

namespace codelou_todo
{
    class Program
    {
        // static variables are variables in which there is ONLY one and can be accessed easily
        //  in practice you shouldn't use static vars like this and in the next lesson we will start moving
        //  away from that.
        // This static variable is a list that can hold multiple todos
        static List<Todo>  Todos = new List<Todo>();
        static void Main(string[] args)
        {
            var shouldContinue = true;
            while(shouldContinue)
            {
                var menuOption = Menu();
                if(menuOption == "1")
                {
                    var todo = CreateTodo();
                    Todos.Add(todo);
                }
                else if(menuOption == "2")
                {
                    ShowTodos();
                }
                else if(menuOption == "3")
                {
                    shouldContinue = false;
                }
                else
                {
                    continue;
                }
            }
        }

        static string Menu()
        {
            Console.WriteLine("Enter 1 , 2 , or 3");
            Console.WriteLine("1. Add a Todo");
            Console.WriteLine("2. View all Todos");
            Console.WriteLine("3. Exit Application");
            return Console.ReadLine();
        }

        static Todo CreateTodo()
        {
            Console.WriteLine("Enter a name for the todo");
            var name = Console.ReadLine();
            var success = false;
            DateTimeOffset dueDate;
            // A do while loop ensures the loop will run at least once and then
            //  test to see if it can run again at the end
            do 
            {
                Console.WriteLine("Enter a date and/or time for the todo");
                var dueDateString = Console.ReadLine();
                
                // TryParse commands exist for all the basic types (string, int, double, datetime, ect) and allow you to 
                //  convert from a string to that specific type. The out parameter is where the value will be stored
                //  and returns true/false if the conversion was successful
                success = DateTimeOffset.TryParse(dueDateString, out dueDate);
                if(!success) // If not successful tell the user
                {
                    Console.WriteLine($"Could not convert {dueDateString} to a proper date time try again");
                }
            }while(!success);

            // Create a new object of todo
            var todo = new Todo();
            // Update the members of that new object with the appropriate value
            todo.Due = dueDate;
            todo.Name = name;
            return todo;
        }

        static void ShowTodos()
        {
            // Iterate over the list and print out the todo
            foreach(var todo in Todos)
            {
                // The $ lets us use the objects directly inside the string instead of doing
                // Console.WriteLine(todo.Name + " due on  " + todo.Due); 
                // OR
                // Console.WriteLine(String.Format(" {0} due on  {1}" ,todo.Due. todo.Due);
                // the way below is a newer way that is MUCH MUCH BETTER!
                Console.WriteLine($"{todo.Name} due on {todo.Due}");
            }
        }
    }
}
